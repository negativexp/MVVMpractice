using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using MongoDB.Driver;

namespace WpfAppMVVMMongoDB.ViewModels
{
    class MainWindowMV : INotifyPropertyChanged
    {
        //this shit needs direct access to database a
        //in order to update datagrid
        public MongoClient _client;
        public IMongoDatabase _database;
        public IMongoCollection<Models.PersonModel> _collection;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DeleteUserCommand;
        public ICommand ListCountCommand;

        public Models.DatabaseModel DatabaseModel { get; } =
            new Models.DatabaseModel();

        public MainWindowMV()
        {
            ConnectToDatabase();
            Items = FetchCollection();
            DeleteUserCommand = new DelegateCommand(RemoveDocument);
            ListCountCommand = new DelegateCommand(ListCount);
            DatabaseModel.ItemsChanged += DatabaseModel_ItemsChanged;
        }

        private void DatabaseModel_ItemsChanged()
        {
            MessageBox.Show("items changed");
        }

        void ListCount(object o)
        {
            MessageBox.Show($"Count:{Items.Count}");
        }

        void ConnectToDatabase()
        {
            _client = new MongoClient("mongodb://127.0.0.1:27017");
            _database = _client.GetDatabase("testing_db");
            _collection = _database.GetCollection<Models.PersonModel>("people");
        }

        List<Models.PersonModel> FetchCollection()
        {
            var results = _collection.Find(_ => true);
            return results.ToList();
        }

        void RemoveDocument(object o)
        {
            if(o is Models.PersonModel person)
            {
                var filter = Builders<Models.PersonModel>.Filter.Eq("Id", person.Id);
                _collection.DeleteOne(filter);
                Items = _collection.Find(_ => true).ToList();
                MessageBox.Show($"User removed: {person.Id}");
            }
        }

        private List<Models.PersonModel> _items;
        public List<Models.PersonModel> Items
        {
            get => _items;
            set
            {
                _items = value;
            }
        }

        public ICommand DeleteUser
        {
            get => DeleteUserCommand;
        }

        public ICommand Count
        {
            get => ListCountCommand;
        }
    }
}
