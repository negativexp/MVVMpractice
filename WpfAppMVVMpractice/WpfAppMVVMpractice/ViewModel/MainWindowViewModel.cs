using System;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfAppMVVMpractice.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        DelegateCommand StartWork;
        public Model.FindPrimeNumber FindPrimeNumber { get; } =
            new Model.FindPrimeNumber();

        public MainWindowViewModel()
        {
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
