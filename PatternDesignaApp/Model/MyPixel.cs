using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PatternDesignaApp.Annotations;
using PatternDesignaApp.UserControls;

namespace PatternDesignaApp.Model
{
    public class MyPixel:INotifyPropertyChanged
    {
        public int Index { get; set; }
        public int Row { get; set; }
        public int Colunm { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Thickness Margin { get; set; }
        //public ICommand ClickCommand { get; set; }


        private Brush _bacground= Brushes.White;

        public Brush Background
        {
            get { return _bacground; }
            set
            {
                _bacground = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}