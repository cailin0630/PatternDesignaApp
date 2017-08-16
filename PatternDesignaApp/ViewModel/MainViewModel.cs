using GalaSoft.MvvmLight;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.Windows.Controls;
using System.Drawing;

namespace PatternDesignaApp.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
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

        private ICollection<Rectangle> _points;

        public ICollection<Rectangle> Points
        {
            get { return _points; }
            set
            {
                _points = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// ªÊ÷∆ª≠≤º
        /// </summary>
        /// <param name="width"></param>
        /// <param name="high"></param>
        private void InitCanvas(int row, int column)
        {
           
            var p = new List<Rectangle>();
            var total = row * column;
            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < column; columnIndex++)
                {
                    var r = new Rectangle
                    {
                        //Margin = new Thickness(columnIndex*10, rowIndex*10,0,0),
                        X = rowIndex * 10,
                        Y = columnIndex * 10,
                        Height = 10,
                        Width = 10,
                    };
                    
                    p.Add(r);
                }
            }
            //EventManager.RegisterClassHandler(typeof(Rectangle), Mouse.MouseDownEvent,
            //    new MouseButtonEventHandler(OnMouseDown), false);
            Points = p;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ok");
        }
    }
}