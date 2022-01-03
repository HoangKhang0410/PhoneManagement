using PhoneManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeDetailPage : ContentPage
    {
        public HomeDetailPage()
        {
            InitializeComponent();
        }

        private async void lstProducts_1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Product;
            var detailPage = new ProductDetailPage();
            detailPage.BindingContext = details;
            await Navigation.PushAsync(detailPage);
        }
    }
}