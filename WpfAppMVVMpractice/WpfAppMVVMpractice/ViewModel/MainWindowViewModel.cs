using System;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;
using System.Windows;

namespace WpfAppMVVMpractice.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        DelegateCommand StartWork;
        DelegateCommand StartFileWriteMessage;

        public Model.FindPrimeNumber FindPrimeNumber { get; } =
            new Model.FindPrimeNumber();

        public event Action MessageChanged;
        private string _message = "mrdkos";
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
            }
        }

        public MainWindowViewModel()
        {
            StartFileWriteMessage = new DelegateCommand(testFunction);
            StartWork = new DelegateCommand(FindPrimeNumber.FindPrimeNumberAsync);
            FindPrimeNumber.ProgressChanged += FindPrimeNumber_ProgressChanged;
            FindPrimeNumber.ResultChanged += FindPrimeNumber_ResultChanged;
        }

        private void FindPrimeNumber_ProgressChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Progress"));
        }
        private void FindPrimeNumber_ResultChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            MessageBox.Show("result changed");
        }
        void testFunction(object o)
        {
            File.WriteAllText("test.txt", Message);
        }

        public ICommand StartFileWrite
        {
            get => StartFileWriteMessage;
        }

        public ICommand Start
        {
            get => StartWork;
        }
        public string Progress
        {
            get => FindPrimeNumber.Progress;
        }
        public string Result
        {
            get => Convert.ToString(FindPrimeNumber.Result);
        }
    }
}
