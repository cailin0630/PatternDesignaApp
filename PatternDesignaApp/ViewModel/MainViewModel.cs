using PatternDesignaApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
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

        private List<MyPixel> _points;

        public List<MyPixel> Points
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

       
      

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ok");
        }
    }
}