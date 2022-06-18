using System;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;
using System.Windows;
using System.Collections.Generic;

namespace WpfAppMVVMTextBoxes.ViewModels
{
    class MainWindowVM
    {
        DelegateCommand WriteFileCommand;

        Models.MainWindowModel MainWindowModel { get; } = new Models.MainWindowModel();

        public MainWindowVM()
        {
            WriteFileCommand = new DelegateCommand(MainWindowModel.WriteFile);
        }

        public ICommand WriteFile
        {
            get => WriteFileCommand;
        }

        public List<Models.TextBoxEntry> Entry
        {
            get => MainWindowModel.Entry;
        }
    }
}
