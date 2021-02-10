using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using MyCoffeeApp.Annotations;
using Xamarin.Forms;

namespace MyCoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : BindableObject
    {

        public ICommand IncreaseCount { get; }

        private int _count = 0;
        private string _countDisplay = "Click me!";

        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncreaseCount);
        }
        
        public string CountDisplay
        {
            get => _countDisplay;
            set
            {
                if (value == _countDisplay) return;

                _countDisplay = value;
                // we can leave this parameter empty
                OnPropertyChanged(nameof(CountDisplay));
            }
        }

        private void OnIncreaseCount()
        {
            _count++;
            CountDisplay = $"You clicked {_count} times";
        }
    }
}
