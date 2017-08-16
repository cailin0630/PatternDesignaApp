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
using PatternDesignaApp.Model;

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

        private static Action<Tuple<int,int>> _callback;
        private static DefineCanvasWindow _defineCanvasWindow;
        public static void ShowDialog(Action<Tuple<int, int>> callAction)
        {
            _defineCanvasWindow = new DefineCanvasWindow
            {
                Owner = Application.Current.MainWindow
            };
            _callback = callAction;
            _defineCanvasWindow.ShowDialog();
           
        }
        private void ConfirmButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (WidthTextBox.Text.IsNullOrWhiteSpace() || HighTextBox.Text.IsNullOrWhiteSpace())
            {
                TipTextBlock.Text = "参数不合法";
                return;
            }
            if (!int.TryParse(WidthTextBox.Text, out int width) || !int.TryParse(HighTextBox.Text, out int high))
            {
                TipTextBlock.Text = "参数不合法";
                return;
            }

            _callback.Invoke(new Tuple<int, int>(width, high));
            Close();
        }
    }
}
