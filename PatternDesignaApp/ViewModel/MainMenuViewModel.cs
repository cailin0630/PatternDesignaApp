using System;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using PatternDesignaApp.Extension;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using PatternDesignaApp.Enums;
using PatternDesignaApp.UserControls;

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

        #endregion

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

        private ICommand _selectChineseLanguageCommand;

        public ICommand SelectChineseLanguageCommand
        {
            get
            {
                _selectChineseLanguageCommand = _selectChineseLanguageCommand ?? new RelayCommand(DoSelectChineseLanguageCommand, () => true);
                return _selectChineseLanguageCommand;
            }
        }
        private ICommand _selectEnglishLanguageCommand;

        public ICommand SelectEnglishLanguageCommand
        {
            get
            {
                _selectEnglishLanguageCommand = _selectEnglishLanguageCommand ?? new RelayCommand(DoSelectEnglishLanguageCommand, () => true);
                return _selectEnglishLanguageCommand;
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


        protected virtual void DoSelectChineseLanguageCommand()
        {
            var dict = new ResourceDictionary
            {
                Source = new Uri(@"Theme\Language\Chinese.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries[0] = dict;
            CurrentLanguage=Language.Chinese;
        }

        protected virtual void DoSelectEnglishLanguageCommand()
        {
            var dict = new ResourceDictionary
            {
                Source = new Uri(@"Theme\Language\English.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries[0] = dict;
            CurrentLanguage=Language.English;
        }
        #endregion DoUcMenuCommand
    }
}