using MyCoffeeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyCoffeeApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}