﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://dotnetgenetics.blogspot.com/2021/02/wpf-crud-with-datagrid-mvvm-entity.html

namespace WpfAppMVVMdatagridOperations.Models
{
    class PersonRecord : ViewModels.ViewModelBase
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        private int _name;
        public int Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PersonRecord> _personRecordList;
        public ObservableCollection<PersonRecord> PersonRecordList
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