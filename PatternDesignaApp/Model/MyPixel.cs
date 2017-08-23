using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using PatternDesignaApp.Annotations;

namespace PatternDesignaApp.Model
{
    public class MyPixelModel:INotifyPropertyChanged
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Thickness Margin { get; set; }
        public ICommand ClickCommand { get; set; }

        private Color _background;

        public Color Background
        {
            get { return _background; }
            set
            {
                _background = value;
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