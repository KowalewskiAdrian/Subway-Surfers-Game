using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyCoffeeApp.Models;
using MyCoffeeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        public CoffeeEquipmentPage()
        {
            InitializeComponent();

            // we can bind the respective ViewModel here or in the XAML file
            //BindingContext = new CoffeeEquipmentViewModel();
        }

        //private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    Console.WriteLine($"ListView_OnItemTapped {sender.ToString()} {sender.GetType()}");
        //    ((ListView) sender).SelectedItem = null;
        //}

        //private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    Console.WriteLine($"ListView_OnItemSelected {sender.ToString()} {sender.GetType()}");
        //    var coffee = ((ListView) sender).SelectedItem as Coffee;
        //    if (coffee == null) return;
        //    await DisplayAlert("Coffee Selected", coffee.Name, "OK");
        //}
        
        //private async void FavoriteItem_OnClicked(object sender, EventArgs e)
        //{
        //    Console.WriteLine("FavoriteItem_OnClicked");
        //    var coffee = ((MenuItem) sender).BindingContext as Coffee;
        //    if (coffee == null) return;
        //    await DisplayAlert("Coffee Favorited", coffee.Name, "OK");
        //}
    }
}
