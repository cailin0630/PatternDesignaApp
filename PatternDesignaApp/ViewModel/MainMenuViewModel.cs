using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using PatternDesignaApp.Enums;
using PatternDesignaApp.Extension;
using System;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using PatternDesignaApp.DailogWindows;

namespace PatternDesignaApp.ViewModel
{
    public partial class MainViewModel
    {
        #region UcMenu Dp

        private Language _currentLanguage;

        public Language CurrentLanguage
        {
            get { return _currentLanguage; }
            set
            {
                _currentLanguage = value;
                RaisePropertyChanged();
            }
        }

        #endregion UcMenu Dp

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

        private ICommand _selectLanguageCommand;

        public ICommand SelectLanguageCommand
        {
            get
            {
                _selectLanguageCommand = _selectLanguageCommand ?? new RelayCommand<object>(DoSelectLanguageCommand, o => true);
                return _selectLanguageCommand;
            }
        }

        #endregion UcMenu Command

        #region DoUcMenuCommand

        public Action<int, int> InitCanvasAction;

        protected virtual void DoNewFileCommand()
        {
            //todo DoNewFileCommand
            DefineCanvasWindow.ShowDialog(result =>
            {
                var width = result.Item1;
                var high = result.Item2;
                //todo 绘制 画布
                InitCanvas(width, high);
                InitCanvasAction.Invoke(width, high);
            });
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
            CurrentImageSource = new BitmapImage(new Uri(fileName));
        }

        protected virtual void DoSaveFileCommand()
        {
            //todo DoSaveFileCommand

            if (CurrentImageSource == null)
                return;
            var bitmap = (CurrentImageSource as BitmapImage).ConvertToBitmap();
            var saveFileDialog = new SaveFileDialog
            {
                Filter = FrameworkConst.SupportedImageFilter,
            };
            if (!saveFileDialog.ShowDialog() ?? false)
                return;
            var fileName = saveFileDialog.FileName;
            bitmap.Save(fileName, ImageFormat.Jpeg);
        }

        protected virtual void DoSaveAsFileCommand()
        {
            //todo DoSaveAsFileCommand
        }

        protected virtual void DoSelectLanguageCommand(object obj)
        {
            var lang = obj.ToString();
            Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary
            {
                Source = new Uri($@"Theme\Default\Language\{lang}.xaml", UriKind.Relative)
            };
            Enum.TryParse(lang, true, out Language newlang);
            CurrentLanguage = newlang;
        }

        #endregion DoUcMenuCommand
    }
}