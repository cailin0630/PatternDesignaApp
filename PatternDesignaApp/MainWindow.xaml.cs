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
using Brush = System.Drawing.Brush;

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
            _mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
            
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
            else if(_mainViewModel.CurrentBrushType == BrushType.多边形)
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
    }

}
