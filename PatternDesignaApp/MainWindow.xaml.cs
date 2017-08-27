
using Microsoft.Practices.ServiceLocation;
using PatternDesignaApp.Enums;
using PatternDesignaApp.UserControls;
using PatternDesignaApp.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using PatternDesignaApp.Model;

namespace PatternDesignaApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            _mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();

            UcTopToolMenu.GridShowOrHideAction += () =>
            {
            };
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void MyButton_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            if (_mainViewModel.CurrentBrushType == BrushType.画笔)
            {
               

                _mainViewModel.Points.FirstOrDefault(p => p.Margin == (sender as Button).Margin).Background = new SolidColorBrush(_mainViewModel.FillColor);
            }
            else if(_mainViewModel.CurrentBrushType == BrushType.矩形)
            {
             
                

            }
        }

        private MyPixel firstPixel;

        private void MyButton_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_mainViewModel.CurrentBrushType == BrushType.矩形)
            {
                var btn = sender as MyButton;
                firstPixel = _mainViewModel.Points.FirstOrDefault(p => p.Margin == btn?.Margin);
            }
           
        }

        private void MyButton_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_mainViewModel.CurrentBrushType == BrushType.矩形)
            {

                var btn = sender as MyButton;
                var lastPixel = _mainViewModel.Points.FirstOrDefault(p => p.Margin == btn?.Margin);
                if (firstPixel != null)
                {
                    //todo 外围按钮
                  
                    var firstRow = firstPixel.Row;
                    var firstColumn = firstPixel.Colunm;
                    var lastRow = lastPixel?.Row;
                    var lastColumn = lastPixel?.Colunm;
                    foreach (var p in _mainViewModel.Points.Where(
                        p => p.Row >= firstRow && p.Row <= lastRow && p.Colunm >= firstColumn &&
                             p.Colunm <= lastColumn).Where(p => (p.Row == firstRow || p.Row == lastRow) || (p.Colunm == firstColumn || p.Colunm == lastColumn)))
                    {
                        p.Background = new SolidColorBrush(_mainViewModel.BorderColor);
                    }
                    foreach (var p in _mainViewModel.Points.Where(
                        p => p.Row >= firstRow && p.Row <= lastRow && p.Colunm >= firstColumn &&
                             p.Colunm <= lastColumn).Where(p => (p.Row != firstRow && p.Row != lastRow) && (p.Colunm != firstColumn && p.Colunm != lastColumn)))
                    {
                        p.Background = new SolidColorBrush(_mainViewModel.FillColor);
                    }
                }

            }
           
        }
    }
}