using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Models;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace MyCoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Coffee> FavoriteCommand { get; }
        public AsyncCommand<object>SelectedCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }

        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";

            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            LoadMore();
            
            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
        }

        private Coffee _previouslySelectedCoffee;
        private Coffee _selectedCoffee;

        public Coffee SelectedCoffee
        {
            get => _selectedCoffee;
            set => SetProperty(ref _selectedCoffee, value);
        }

        private async Task Selected(object args)
        {
            Coffee coffee = args as Coffee;
            if (coffee == null) return;
            SelectedCoffee = null;
            await Application.Current.MainPage.DisplayAlert("Selected", coffee.Name, "Ok");
        }

        private async Task Favorite(Coffee coffee)
        {
            if (coffee == null) return;
            await Application.Current.MainPage.DisplayAlert("Favorite", coffee.Name, "OK");
        }

        private async Task Refresh()
        {
            IsBusy = true;
            
            await Task.Delay(2000);
            
            Coffee.Clear();
            LoadMore();

            IsBusy = false;
        }

        private void LoadMore()
        {
            int max = 20;
            if (Coffee.Count >= max) return;

            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });

            CoffeeGroups.Clear();

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.Roaster == "Blue Bottle")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(coffee => coffee.Roaster == "Yes Plz")));
        }

        private void DelayLoadMore()
        {
            if (Coffee.Count <= 10) return;
            LoadMore();
        }

        private void Clear()
        {
            Coffee.Clear();
            CoffeeGroups.Clear();
        }


    }
}

