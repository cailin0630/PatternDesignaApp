using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PatternDesignaApp.UserControls
{
    public class MyButton:Button
    {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            e.Handled = false;
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            e.Handled = false;
        }
    }

    public class MyPoint : ContentControl, ICommandSource
    {
        
        public ICommand Command { get; }
        public object CommandParameter { get; }
        public IInputElement CommandTarget { get; }
    }
}
