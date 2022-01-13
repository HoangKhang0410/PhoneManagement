using PhoneManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailPage : ContentPage
    {
 
        public OrderDetailPage()
        {
            InitializeComponent();
        }
        public OrderDetailPage(ObservableCollection<OrderProductDetailModel> x, OrderModel y)
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#F78700");
            lstdetail.ItemsSource = x;
            lblnote.Text = y.ORDERNOTE;
            lbltongtien.Text = y.ORDERTOTAL.ToString();

        }
    }
}