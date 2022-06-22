using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfAppMVVMdatagridOperations.ViewModels
{
    class MainWindowViewModel
    {
        private DataAccess.PersonRepo _personRepo;
        private Models.Person _personEntity = null;
        public Models.PersonRecord PersonRecord { get; set; }


        ICommand _addCommand;

        public MainWindowViewModel()
        {
            _personRepo = new DataAccess.PersonRepo();
            PersonRecord = new Models.PersonRecord();
            _personEntity = new Models.Person();

            _addCommand = new RelayCommand(param => AddPerson(), null);
            GetAll();
        }

        public ICommand AddCommand
        {
            get => _addCommand;
        }

        public void AddPerson()
        {
            _personEntity.Id = PersonRecord.Id;
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

        public void ResetData()
        {
            PersonRecord.Id = 0;
            PersonRecord.Name = String.Empty;
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
