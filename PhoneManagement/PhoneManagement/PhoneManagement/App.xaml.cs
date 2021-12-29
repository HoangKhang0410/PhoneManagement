using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneManagement
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.ProductDetailPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public static MasterDetailPage MasterDet { get; set; }
    }
}
