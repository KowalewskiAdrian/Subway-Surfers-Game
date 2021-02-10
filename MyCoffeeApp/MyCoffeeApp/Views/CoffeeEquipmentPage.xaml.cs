using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            BindingContext = new CoffeeEquipmentViewModel();
        }

        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            Console.WriteLine($"Toggle: {e.Value} sender:{sender}");
        }

    }
}
