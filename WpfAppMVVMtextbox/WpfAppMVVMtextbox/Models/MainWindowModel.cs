using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace WpfAppMVVMtextbox.Models
{
    class MainWindowModel
    {
        private string _name;
        private string _age;
        private string _job;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Age
        {
            get => _age;
            set => _age = value;
        }
        public string Job
        {
            get => _job;
            set => _job = value;
        }

        public void CreateFile(object o)
        {
            string x = $"{_name} ; {_age} ; {_job}";
            File.WriteAllText("data.txt", x);
            MessageBox.Show("File created");
        }
    }
}
