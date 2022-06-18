using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfAppMVVMMongoDB.Models
{
    class DatabaseModel
    {
        MongoClient _client;
        MongoDatabaseBase _database;
        MongoCollectionBase<Models.PersonModel> _collection;

        public event Action ItemsChanged;
        private List<Models.PersonModel> _items;
        public List<Models.PersonModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                ItemsChanged?.Invoke();
            }
        }

        public DatabaseModel()
        {

        }

    }
}
