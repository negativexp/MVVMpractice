using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;

namespace WpfAppMVVMdatagrid.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public PropertyChangedEventHandler PropertyChanged;

        DelegateCommand DisplayIdCommand;
        DelegateCommand RemoveItemCommand;
        DelegateCommand CountItemsCommand;
        DelegateCommand TestFunctionCommand;


        public Models.MainWindowModel MainWindowModel { get; } = new Models.MainWindowModel();

        public MainWindowViewModel()
        {
            //load

            //commands
            DisplayIdCommand = new DelegateCommand(MainWindowModel.DisplayItemId);
            CountItemsCommand = new DelegateCommand(MainWindowModel.CountItems);
            TestFunctionCommand = new DelegateCommand(MainWindowModel.TestFunction);
            //invokers
            MainWindowModel.ItemsChanged += MainWindowModel_ItemsChanged;
        }

        private void MainWindowModel_ItemsChanged()
        {
            PropertyChanged?.

            MessageBox.Show("mrdkos");
        }

        public List<Models.Item> Items
        {
            get => MainWindowModel.Items;
        }

        public ICommand DisplayId
        {
            get => DisplayIdCommand;
        }

        public ICommand RemoveItem
        {
            get => RemoveItemCommand;
        }

        public ICommand CountItems
        {
            get => CountItemsCommand;
        }

        public ICommand TestFunction
        {
            get => TestFunctionCommand;
        }
    }
}
