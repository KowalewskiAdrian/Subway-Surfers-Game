using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Models;
using MyCoffeeApp.Services;
using Xamarin.Forms;

namespace MyCoffeeApp.ViewModels
{
    public class MyCoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Coffee> RemoveCommand { get; }


        public MyCoffeeViewModel()
        {
            Title = "My Coffee";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
        }

        private async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of coffee");
            var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Roaster of coffee");
            await CoffeeService.AddCoffee(name, roaster);
            await Refresh();
        }

        private async Task Remove(Coffee coffee)
        {
            await CoffeeService.RemoveCoffee(coffee.Id);
            await Refresh();
        }

        private async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);
            Coffee.Clear();
            var coffees = await CoffeeService.GetCoffee();

            Coffee.AddRange(coffees);
            IsBusy = false;
        }
    }
}