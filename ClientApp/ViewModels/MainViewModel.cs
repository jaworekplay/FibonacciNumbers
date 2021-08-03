using ClientApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        ClientApp.Service.Service _apiService;
        public MainViewModel()
        {
            _apiService = new Service.Service("https://localhost:44391/", new System.Net.Http.HttpClient(new HttpClientHandler { UseDefaultCredentials = true }));//the url could be in a config file
            
            GetNumbersCommand = new RelayCommand(GetNumbers);
            GetEvenNumbersCommand = new RelayCommand(GetEvenNumber);
            FibonacciNumbers = new ObservableCollection<int>();
        }

        private async void GetEvenNumber(object obj)
        {
            FibonacciNumbers.Clear();
            var fibonacciNumbers = await _apiService.FibonacciEvenNumbersAllAsync();
            foreach (var number in fibonacciNumbers)
            {
                FibonacciNumbers.Add(number);
            }
        }

        private ObservableCollection<int> fibonacciNumbers;

        public ObservableCollection<int> FibonacciNumbers
        {
            get { return fibonacciNumbers; }
            set { fibonacciNumbers = value; OnPropertyChanged(); }
        }

        private async void GetNumbers(object obj)
        {
            FibonacciNumbers.Clear();
            var fibonacciNumbers = await _apiService.FibonacciAllAsync();
            foreach (var number in fibonacciNumbers)
            {
                FibonacciNumbers.Add(number);
            }
        }

        public IRelayCommand GetNumbersCommand { get; set; }

        public IRelayCommand GetEvenNumbersCommand { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
