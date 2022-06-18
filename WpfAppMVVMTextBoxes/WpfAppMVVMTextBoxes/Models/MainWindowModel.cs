using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppMVVMTextBoxes.Models
{
    class MainWindowModel
    {
        private List<Models.TextBoxEntry> _entry;
        public List<Models.TextBoxEntry> Entry
        {
            get => _entry;
            set => _entry = value;
        }

        public void WriteFile(object o)
        {
            foreach(var entry in Entry)
            {
                MessageBox.Show(entry.ToString());
            }
        }
    }
}
