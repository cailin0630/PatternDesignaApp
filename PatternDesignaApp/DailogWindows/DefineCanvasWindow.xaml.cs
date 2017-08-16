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
using System.Windows.Shapes;
using PatternDesignaApp.Extension;

namespace PatternDesignaApp.DailogWindows
{
    /// <summary>
    /// DefineCanvasWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DefineCanvasWindow : Window
    {
        public DefineCanvasWindow()
        {
            InitializeComponent();
            
        }
        
        private static DefineCanvasWindow _defineCanvasWindow;
        public new static Tuple<int,int> ShowDialog()
        {
            _defineCanvasWindow = new DefineCanvasWindow
            {
                Owner = Application.Current.MainWindow
            };
            ((Window) _defineCanvasWindow).ShowDialog();
           return new Tuple<int, int>(0,0);
        }
        private void ConfirmButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (WidthTextBox.Text.IsNullOrWhiteSpace() || HighTextBox.Text.IsNullOrWhiteSpace())
            {
                TipTextBlock.Text = "参数不合法";
                return;
            }
        }
    }
}
