using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MongoDB.Bson;

namespace WpfAppMVVMdatagridOperations.ViewModels
{
    class MainWindowViewModel
    {
        private DataAccess.PersonRepo _personRepo;
        private Models.Person _personEntity = null;
        public Models.PersonRecord PersonRecord { get; set; }


        ICommand _addCommand;
        ICommand _deleteCommand;

        public MainWindowViewModel()
        {
            _personRepo = new DataAccess.PersonRepo();
            PersonRecord = new Models.PersonRecord();
            _personEntity = new Models.Person();

            _addCommand = new RelayCommand(param => AddPerson(), null);
            _deleteCommand = new RelayCommand(param => DeletePerson(param), null);
            GetAll();
        }

        public ICommand AddCommand
        {
            get => _addCommand;
        }

        public ICommand DeleteCommand
        {
            get => _deleteCommand;
        }

        public void AddPerson()
        {
            _personEntity.Name = PersonRecord.Name;
            try
            {
                _personRepo.AddPerson(_personEntity);
            }
            catch(Exception ex) { MessageBox.Show($"something went wrong:\n{ex.ToString()}"); }
            finally
            {
                GetAll();
                ResetData();
            }
        }

        public void DeletePerson(object obj)
        {
            if(obj is Models.Person person)
            {
                try
                {
                    ObjectId id = ObjectId.Parse(person.Id);
                    _personRepo.DeletePerson(id);
                }
                catch (Exception ex) { MessageBox.Show($"something went wrong\n{ex.ToString()}"); }
                finally
                {
                    GetAll();
                }
            }
        }

        public void ResetData()
        {
            _personEntity.Name = String.Empty;
            _personEntity.Id = String.Empty;
        }

        public void GetAll()
        {
            PersonRecord.PersonRecordList = new List<Models.Person>();
            _personRepo.GetAll().ForEach(data => PersonRecord.PersonRecordList.Add(new Models.Person()
            {
                Id = data.Id,
                Name = data.Name,
            }));
        }
    }
}
