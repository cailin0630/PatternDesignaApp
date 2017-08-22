using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;


namespace PatternDesignaApp.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }

        public class MyPoint
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public Thickness Margin { get; set; }
        }


        private ImageSource _currentImageSource;

        public ImageSource CurrentImageSource
        {
            get { return _currentImageSource; }
            set
            {
                _currentImageSource = value;
                RaisePropertyChanged();
            }
        }

        private ICollection<MyPoint> _points;

        public ICollection<MyPoint> Points
        {
            get { return _points; }
            set
            {
                _points = value;
                RaisePropertyChanged();
            }
        }

        private int _currentRow;

        public int CurrentRow
        {
            get { return _currentRow; }
            set
            {
                _currentRow = value;
                RaisePropertyChanged();
            }
        }
        private int _currentColumn;

        public int CurrentColumn
        {
            get { return _currentColumn; }
            set
            {
                _currentColumn = value;
                RaisePropertyChanged();
            }
        }

        private Color _fillColor;

        public Color FillColor
        {
            get { return _fillColor; }
            set
            {
                _fillColor = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// ªÊ÷∆ª≠≤º
        /// </summary>
        /// <param name="width"></param>
        /// <param name="high"></param>
        //private void InitCanvas(int row, int column)
        //{
        //    //DoCommand(() =>
        //    //{
        //        var p = new List<RectangleGeometry>();
        //        var total = row * column;
        //        for (int rowIndex = 0; rowIndex < row; rowIndex++)
        //        {
        //            for (int columnIndex = 0; columnIndex < column; columnIndex++)
        //            {
        //                var r = new RectangleGeometry
        //                {
        //                    //Margin = new Thickness(columnIndex*10, rowIndex*10,0,0),
        //                    //X = rowIndex * 10,
        //                    //Y = columnIndex * 10,
        //                    //Height = 10,
        //                    //Width = 10,
        //                    Rect = new Rect
        //                    {
        //                        X = rowIndex * 20,
        //                        Y = columnIndex * 20,
        //                        Height = 20,
        //                        Width = 20,
        //                    }
        //                };
        //                var button=new Button
        //                {
        //                    Height = 20,
        //                    Width = 20,
        //                    Margin = new Thickness(columnIndex * 10, rowIndex * 10, 0, 0),
        //                };
        //                p.Add(r);
        //            }
        //        }
        //        //EventManager.RegisterClassHandler(typeof(Rectangle), Mouse.MouseDownEvent,
        //        //    new MouseButtonEventHandler(OnMouseDown), false);
        //        Points = p;
        //    //});
        //}


        private void InitCanvas(int row, int column)
        {
            //DoCommand(() =>
            //{
            var p = new List<MyPoint>();
            var total = row * column;
            //for (int i = 0; i < total; i++)
            //{
            //    p.Add(i);
            //}
            CurrentColumn = column;
            CurrentRow = row;
            var time = new Stopwatch();
            time.Start();
            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < column; columnIndex++)
                {
                    //var r = new RectangleGeometry
                    //{
                    //    //Margin = new Thickness(columnIndex*10, rowIndex*10,0,0),
                    //    //X = rowIndex * 10,
                    //    //Y = columnIndex * 10,
                    //    //Height = 10,
                    //    //Width = 10,
                    //    Rect = new Rect
                    //    {
                    //        X = rowIndex * 20,
                    //        Y = columnIndex * 20,
                    //        Height = 20,
                    //        Width = 20,
                    //    }
                    //};
                    var button = new MyPoint
                    {
                        Height = 20,
                        Width = 20,
                        Margin = new Thickness(columnIndex * 20, rowIndex * 20, 0, 0),
                        
                    };
                    //Console.WriteLine(button.Margin);

                    p.Add(button);
                }
            }
           
            //EventManager.RegisterClassHandler(typeof(Rectangle), Mouse.MouseDownEvent,
            //    new MouseButtonEventHandler(OnMouseDown), false);
            Points = p;
            time.Stop();
            Console.WriteLine(time.ElapsedMilliseconds);
            //});
        }
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ok");
        }


    }
}