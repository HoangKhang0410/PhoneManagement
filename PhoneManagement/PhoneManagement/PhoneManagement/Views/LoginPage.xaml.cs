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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new HomePage());
            string[] arr = new string[] { TK.Text, MK.Text };
            loginBtn.CommandParameter = arr;
        }

        private void registerBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}