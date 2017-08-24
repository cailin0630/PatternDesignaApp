using PatternDesignaApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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

        private List<MyPixelModel> _points;

        public List<MyPixelModel> Points
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
        private Color _borderColor;

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
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

       
        private void InitCanvas(int row, int column)
        {
            //DoCommand(() =>
            //{
            //    var p = new List<MyPixelModel>();
            //var total = row * column;

            //CurrentColumn = column;
            //CurrentRow = row;
            //var time = new Stopwatch();
            //time.Start();
            //int index = 1;
            //for (int rowIndex = 0; rowIndex < row; rowIndex++)
            //{
            //    for (int columnIndex = 0; columnIndex < column; columnIndex++)
            //    {
            //        var button = new MyPixelModel
            //        {
            //            Row = rowIndex+1,
            //            Colunm = columnIndex+1,
            //            Index = index,
            //            Height = 20,
            //            Width = 20,
            //            Margin = new Thickness(columnIndex * 20, rowIndex * 20, 0, 0),
            //        };
            //        index++;

            //        p.Add(button);
            //    }
            //}

            //Points = p;
            //time.Stop();
            //Console.WriteLine(time.ElapsedMilliseconds);
            //    return true;
            //});
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ok");
        }
    }
}