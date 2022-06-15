using System;
using System.Threading.Tasks;
using System.IO;

namespace WpfAppMVVMpractice.Model
{
    public class FindPrimeNumber
    {
        public event Action ProgressChanged;
        public event Action ResultChanged;

        private string _progress = "not start";
        private long _result = 0;

        public long Result
        {
            get => _result;
            set
            {
                _result = value;
                ResultChanged?.Invoke();
            }
        }
        public string Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                ProgressChanged?.Invoke();
            }
        }
        public async void FindPrimeNumberAsync(object o)
        {
            await Task.Run(_FindPrimeNumber);
            //_FindPrimeNumber();
        }
        public Random _radnom { get; } = new Random();

        void _FindPrimeNumber()
        {
            int n = 100000;
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
                Progress = count.ToString();
            }
            Progress = count.ToString() + " (Done)";
            Result = --a;
            //return (--a);
        }
    }
}
