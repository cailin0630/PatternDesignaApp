using System;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using PatternDesignaApp.Extension;
using System.Drawing;
using System.Drawing.Imaging;

namespace PatternDesignaApp.ViewModel
{
    public partial class MainViewModel
    {
        #region UcMenu Command

        private ICommand _newFileCommand;

        public ICommand NewFileCommand
        {
            get
            {
                _newFileCommand = _newFileCommand ?? new RelayCommand(DoNewFileCommand, () => true);
                return _newFileCommand;
            }
        }

        private ICommand _openFileCommand;

        public ICommand OpenFileCommand
        {
            get
            {
                _openFileCommand = _openFileCommand ?? new RelayCommand(DoOpenFileCommand, () => true);
                return _openFileCommand;
            }
        }

        private ICommand _saveFileCommand;

        public ICommand SaveFileCommand
        {
            get
            {
                _saveFileCommand = _saveFileCommand ?? new RelayCommand(DoSaveFileCommand, () => true);
                return _saveFileCommand;
            }
        }

        private ICommand _saveAsFileCommand;

        public ICommand SaveAsFileCommand
        {
            get
            {
                _saveAsFileCommand = _saveAsFileCommand ?? new RelayCommand(DoSaveAsFileCommand, () => true);
                return _saveAsFileCommand;
            }
        }

        #endregion UcMenu Command

        #region DoUcMenuCommand

        protected virtual void DoNewFileCommand()
        {
            //todo DoNewFileCommand
        }

        protected virtual void DoOpenFileCommand()
        {
            //todo DoOpenFileCommand
            var openFileDialog = new OpenFileDialog
            {
                Filter = FrameworkConst.SupportedImageFilter,
                Multiselect = false
            };
            if (!openFileDialog.ShowDialog() ?? false)
                return;
            var fileName = openFileDialog.FileName;
            CurrentImageSource=new BitmapImage(new Uri(fileName));
        }

        protected virtual void DoSaveFileCommand()
        {
            //todo DoSaveFileCommand
            
            if(CurrentImageSource==null)
                return;
            var bitmap = (CurrentImageSource as BitmapImage).ConvertToBitmap();
            var saveFileDialog=new SaveFileDialog
            {
               Filter = FrameworkConst.SupportedImageFilter,
            };
            if(!saveFileDialog.ShowDialog()??false)
                return;
            var fileName = saveFileDialog.FileName;
            bitmap.Save(fileName, ImageFormat.Jpeg);
        }

        protected virtual void DoSaveAsFileCommand()
        {
            //todo DoSaveAsFileCommand
        }

        #endregion DoUcMenuCommand
    }
}