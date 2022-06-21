using System;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;
using System.Windows;

namespace WpfAppMVVMtextbox.ViewModels
{
    class MainWindowViewModel
    {
        private Models.MainWindowModel MainWindowModel;

        DelegateCommand WriteFileCommand;

        public MainWindowViewModel()
        {
            MainWindowModel = new Models.MainWindowModel();
            WriteFileCommand = new DelegateCommand(MainWindowModel.CreateFile);
        }

        public Models.MainWindowModel TextBoxes
        {
            get => MainWindowModel;
            set => MainWindowModel = value;
        }

        public ICommand WriteFile
        {
            get => WriteFileCommand;
        }
    }
}
