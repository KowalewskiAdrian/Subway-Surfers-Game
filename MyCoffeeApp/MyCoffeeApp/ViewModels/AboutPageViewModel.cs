using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace MyCoffeeApp.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        public ICommand IncreaseCount { get; }

        private int _count = 0;
        private string _countDisplay = "Click me!";

        public AboutPageViewModel()
        {
            IncreaseCount = new Command(OnIncreaseCount);

            // Can't do that - because it's expected an Action, not an async Task
            //CallServerCommand = new Command(CallServerAsync);

            // A not elegant hack - could swallow up exceptions
            //CallServerCommand = new Command(async () => await CallServerAsync());

            // With MvvmHelpers asyncCommand
            CallServerCommand = new AsyncCommand(CallServerAsync);

            Coffee = new ObservableRangeCollection<string>();

            Title = "Coffee Equipment";
            Subtitle = "Keep tabs on your equipments";
            Header = "Header";
            Footer = "daltonlima.com";
        }

        // Built-in System.Collections.ObjectModel - lacks AddRange and similar ones
        //public ObservableCollection<string> Coffee { get; }

        // Mvvmhelpers have this covered
        public ObservableRangeCollection<string> Coffee { get; }

        public ICommand CallServerCommand { get; }

        async Task CallServerAsync()
        {
            Coffee.Add("Yes Plz");
            Coffee.Add("Tonx");
            Coffee.Add("Blue Bottle");

            var coffeeList = new List<string> { "Yes Plz", "Tonx", "Blue Bottle" };
            Coffee.AddRange(coffeeList);

            await Task.Delay(3000);

            // have callbacks when exceptions happens

            // CanExecute

            // Handle Capture threading ?
        }

        public string CountDisplay
        {
            get => _countDisplay;
            // Mvvmhelpers package handles extra things for us, keeping code simple.
            set => SetProperty(ref _countDisplay, value, "", null, null);
            //set
            //{
            //    if (value == _countDisplay) return;

            //    _countDisplay = value;
            //    // we can leave this parameter empty
            //    OnPropertyChanged(nameof(CountDisplay));
            //}
        }

        private void OnIncreaseCount()
        {
            _count++;
            CountDisplay = $"You clicked {_count} times";
        }

    }
}
