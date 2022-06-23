using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

//https://dotnetgenetics.blogspot.com/2021/02/wpf-crud-with-datagrid-mvvm-entity.html

namespace WpfAppMVVMdatagridOperations.Models
{
    class PersonRecord : ViewModels.ViewModelBase
    {
        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private List<Person> _personRecordList;
        public List<Person> PersonRecordList
        {
            get => _personRecordList;
            set
            {
                _personRecordList = value;
                OnPropertyChanged();
            }
        }

        private void PersonModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }
    }
}
