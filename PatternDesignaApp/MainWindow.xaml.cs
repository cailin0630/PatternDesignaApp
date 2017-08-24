using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.ServiceLocation;
using PatternDesignaApp.Enums;
using PatternDesignaApp.ViewModel;


namespace PatternDesignaApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            _mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
            _mainViewModel.InitCanvasAction += (w, h) =>
            {
                MyCanvas.Children.Clear();
                MyCanvas.Width = w;
                MyCanvas.Height = h;
                MyCanvas.Background = _gridBrush;
                _gridShow = true;
                UcBottomToolMenu.SetWidthAndHight(w,h);
            };
            UcTopToolMenu.GridShowOrHideAction += () =>
            {
                MyCanvas.Background = _gridShow? _baseBrush:_gridBrush;
                _gridShow = !_gridShow;
            };
        }

        private bool _gridShow;
        private DrawingBrush _gridBrush;
        private Brush _baseBrush=new SolidColorBrush(Colors.White);
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (_gridBrush == null)
            {

                _gridBrush = new DrawingBrush(new GeometryDrawing(
                    new SolidColorBrush(Colors.White),
                    new Pen(new SolidColorBrush(Colors.LightGray), 1.0),
                    new RectangleGeometry(new Rect(0, 0, 10, 10))))
                {
                    Stretch = Stretch.None,
                    TileMode = TileMode.Tile,
                    Viewport = new Rect(0.0, 0.0, 10, 10),
                    ViewportUnits = BrushMappingMode.Absolute
                };

              




                //MyCanvas.Background = _gridBrush;

            }
        }

        private bool _mousePress;
        private int _firstIndex;
        private readonly MainViewModel _mainViewModel;

        private void Button_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if(!_mousePress)return;
            if (_mainViewModel.CurrentBrushType == BrushType.画笔)
            {
                var fillColor = _mainViewModel.FillColor;
                (sender as Button).Background = new SolidColorBrush(fillColor);
                _mainViewModel.Points.FirstOrDefault(p => p.Margin == (sender as Button).Margin).Background = new SolidColorBrush(_mainViewModel.FillColor);
            }
            else if(_mainViewModel.CurrentBrushType == BrushType.矩形)
            {
                var mypoint = _mainViewModel.Points.FirstOrDefault(p => p.Margin == (sender as Button).Margin);
                mypoint.Background = new SolidColorBrush(_mainViewModel.FillColor);
                var currentIndex = mypoint.Index;
                
            }
          

        }

      

       

        private void Button_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mousePress = true;
            if (_mainViewModel.CurrentBrushType == BrushType.画笔)
            {
                var fillColor = _mainViewModel.FillColor;
                (sender as Button).Background = new SolidColorBrush(fillColor);
                var mypoint = _mainViewModel.Points.FirstOrDefault(p => p.Margin == (sender as Button).Margin);
                mypoint.Background = new SolidColorBrush(_mainViewModel.FillColor);
                _firstIndex = mypoint.Index;
            }
         
        }

        private void Button_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _mousePress = false;
         
        }

        private Line myLine;
        private Ellipse myEllipse;
        private Rectangle myRectangle;
        private Point _pointStart;
        private Point _pointEnd;
        private void MyCanvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mousePress = true;
            if (_mainViewModel.CurrentBrushType == BrushType.画笔)
            {
                myLine = new Line();
                myLine.Stroke =new SolidColorBrush(_mainViewModel.FillColor);
                var point = e.GetPosition(MyCanvas);
                myLine.X1 = point.X;

                myLine.Y1 = point.Y;

                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Center;
                myLine.StrokeThickness = 2;
            }
            else if(_mainViewModel.CurrentBrushType==BrushType.圆)
            {
                myEllipse = new Ellipse();

             
                //SolidColorBrush mySolidColorBrush = new SolidColorBrush();

             
                //mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
                myEllipse.Fill = new SolidColorBrush(_mainViewModel.FillColor);
                myEllipse.StrokeThickness = 2;
                myEllipse.Stroke = new SolidColorBrush(_mainViewModel.BorderColor);

                _pointStart = e.GetPosition(MyCanvas);

            }
            else if(_mainViewModel.CurrentBrushType==BrushType.矩形)
            {

                myRectangle = new Rectangle();


                //SolidColorBrush mySolidColorBrush = new SolidColorBrush();


                //mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
                myRectangle.Fill = new SolidColorBrush(_mainViewModel.FillColor);
                myRectangle.StrokeThickness = 2;
                myRectangle.Stroke = new SolidColorBrush(_mainViewModel.BorderColor);

                _pointStart = e.GetPosition(MyCanvas);
            }
            
           
        }

        private void MyCanvas_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_mainViewModel.CurrentBrushType == BrushType.画笔)
            {
                var point = e.GetPosition(MyCanvas);
                myLine.X2 = point.X;
                myLine.Y2 = point.Y;
                MyCanvas.Children.Add(myLine);
            }
            else if(_mainViewModel.CurrentBrushType == BrushType.圆)
            {
                _pointEnd = e.GetPosition(MyCanvas);
                var width =Math.Abs( _pointEnd.X - _pointStart.X);
                var heigh = Math.Abs( _pointEnd.Y - _pointStart.Y);
                myEllipse.Width = width;
                myEllipse.Height = heigh;
                myEllipse.Margin=new Thickness(_pointStart.X, _pointStart.Y,0,0);
                // Add the Ellipse to the StackPanel.
                MyCanvas.Children.Add(myEllipse);
            }
            else if(_mainViewModel.CurrentBrushType == BrushType.矩形)
            {
                _pointEnd = e.GetPosition(MyCanvas);
                var width = Math.Abs(_pointEnd.X - _pointStart.X);
                var heigh = Math.Abs(_pointEnd.Y - _pointStart.Y);
                myRectangle.Width = width;
                myRectangle.Height = heigh;
                myRectangle.Margin = new Thickness(_pointStart.X, _pointStart.Y, 0, 0);
                // Add the Ellipse to the StackPanel.
                MyCanvas.Children.Add(myRectangle);
            }
          
        }


        //private void MyCanvas_OnMouseMove(object sender, MouseEventArgs e)
        //{
        //    if (_mainViewModel.CurrentBrushType == BrushType.画笔&& _mousePress)
        //    {
        //        var point = e.GetPosition(MyCanvas);
        //        myLine.X2 = point.X;
        //        myLine.Y2 = point.Y;
        //        MyCanvas.Children.Add(myLine);
        //    }

          
        //}
    }

}
