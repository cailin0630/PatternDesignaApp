using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using PatternDesignaApp.Annotations;

namespace PatternDesignaApp.Model
{
    public class MyPixelModel
    {
        public int Index { get; set; }
        public int Row { get; set; }
        public int Colunm { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Thickness Margin { get; set; }
        //public ICommand ClickCommand { get; set; }



        public Brush Background { get; set; } = Brushes.White;



    }
}