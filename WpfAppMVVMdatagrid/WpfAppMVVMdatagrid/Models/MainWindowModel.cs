using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace WpfAppMVVMdatagrid.Models
{
    public class MainWindowModel
    {
        public event Action ItemsChanged;

        private List<Models.Item> _items;
        public List<Models.Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                ItemsChanged?.Invoke();
            }
        }

        public MainWindowModel()
        {
            Items = new List<Models.Item>
            {
                new Models.Item {Id=0,Name="bruh"},
                new Models.Item {Id=1,Name="mrdko"},
                new Models.Item {Id=2,Name="debile"},
                new Models.Item {Id=3,Name="brukokote"}
            };
        }

        public void DisplayItemId(object o)
        {
            Models.Item item = o as Models.Item;
            MessageBox.Show(item.Id.ToString());
        }

        public void ItemRemove(object o)
        {
            if(o is Models.Item item)
            {
                Items.Remove(item);
            }
        }

        public void CountItems(object o)
        {
            List<Models.Item> list = o as List<Models.Item>;
            MessageBox.Show("items: " + list.Count.ToString());
        }

        public void TestFunction(object o)
        {
            Items.RemoveAt(0);
        }
    }
}
