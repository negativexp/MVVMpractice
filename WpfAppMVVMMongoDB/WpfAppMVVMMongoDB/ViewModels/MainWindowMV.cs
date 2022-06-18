using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace WpfAppMVVMMongoDB.ViewModels
{
    class MainWindowMV : INotifyPropertyChanged
    {
        //this shit needs direct access to database a
        //in order to update datagrid

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand InsertPersonCommand;

        public Models.DatabaseModel DatabaseModel { get; } =
            new Models.DatabaseModel();

        public MainWindowMV()
        {
            InsertPersonCommand = new DelegateCommand(DatabaseModel.AddPerson);
            DatabaseModel.ItemsChanged += DatabaseModel_ItemsChanged;
        }

        private void DatabaseModel_ItemsChanged()
        {
            MessageBox.Show($"count: {Items.Count}");
        }

        public List<Models.PersonModel> Items
        {
            get => DatabaseModel.Items;
        }

        public ICommand InserPerson
        {
            get => InsertPersonCommand;
        }
    }
}
