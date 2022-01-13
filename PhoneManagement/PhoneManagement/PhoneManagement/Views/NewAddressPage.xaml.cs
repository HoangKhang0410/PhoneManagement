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
    public partial class NewAddressPage : ContentPage
    {
        public NewAddressPage()
        {
            InitializeComponent();
            
        }

        private void addNewBtn_Clicked(object sender, EventArgs e)
        {
            string[] arr = new string[]
            {
                customerName.Text,
                customerAddress.Text,
                customerPhone.Text,
            };
            addNewBtn.CommandParameter = arr;
        }
    }
}