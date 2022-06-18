using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVMTextBoxes.Models
{
    class TextBoxEntry
    {
        private string _textbox1;
        public string Textbox1
        {
            get { return _textbox1; }
            set { _textbox1 = value; }
        }
        private string _textbox2;
        public string Textbox2
        {
            get { return _textbox2; }
            set { _textbox2 = value; }
        }
        private string _textbox3;
        public string Textbox3
        {
            get { return _textbox3; }
            set { _textbox3 = value; }
        }
        private string _textbox4;
        public string Textbox4
        {
            get { return _textbox4; }
            set { _textbox4 = value; }
        }
    }
}
