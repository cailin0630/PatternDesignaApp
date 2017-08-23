using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using PatternDesignaApp.Enums;

namespace PatternDesignaApp.ViewModel
{
    public partial class MainViewModel
    {
       
        //todo UcLeftToolMenu action command
        public BrushType CurrentBrushType { get; set; }

        private ICommand _selectHbCommand;

        public ICommand SelectHbCommand
        {
            get {
                _selectHbCommand = _selectHbCommand ?? new RelayCommand(() =>
            {
                CurrentBrushType=BrushType.画笔;
            }, () => true);
                return _selectHbCommand;
            }
        }

        private ICommand _selectDbxCommand;

        public ICommand SelectDbxCommand
        {
            get
            {
                _selectDbxCommand = _selectDbxCommand ?? new RelayCommand(() =>
                {
                    CurrentBrushType = BrushType.多边形;
                }, () => true);
                return _selectDbxCommand;
            }
        }
    }
}
