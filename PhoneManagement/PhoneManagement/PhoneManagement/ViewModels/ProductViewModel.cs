using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using PhoneManagement.Models;
using PhoneManagement.Views;
using Xamarin.Forms;

namespace PhoneManagement.ViewModels
{
    public class ProductViewModel:INotifyPropertyChanged
    {
        Product product;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    public Product PRODUCT
        {
            get { return product; }
            set { 
                product = value;
                OnPropertyChanged("PRODUCT");
            }
        }

        async void GetProduct()
        {
            HttpClient http = new HttpClient();
            var list = await http.GetStringAsync("http://www.wjbu-project.somee.com/api/ProductController/GetProductWithID?id=1");
            var listConvert = JsonConvert.DeserializeObject<List<Product>>(list);
            PRODUCT = new Product
            {
                ProductName = listConvert[0].ProductName,
                ProductID = listConvert[0].ProductID,
                ProductImg = listConvert[0].ProductImg,
                ProductPrice = listConvert[0].ProductPrice,
                ProductQuanity = listConvert[0].ProductQuanity,
                ProductStatus = listConvert[0].ProductStatus,
                CategoryID = listConvert[0].CategoryID
            };


        }

        public ICommand AddToCart { get; private set; }
        async void AddToCartFunc()
        {
            HttpClient http = new HttpClient();
            var oke = await http.GetStringAsync("http://www.wjbu-project.somee.com/api/CartController/AddToCart?accountID=1" + "&productID=" + 1);
            bool succeed = false;
            Boolean.TryParse(oke, out succeed);
            if (succeed)
            {
                await Application.Current.MainPage.DisplayAlert("Thong bao", "Them san pham vao gio hang thanh cong", "OK");
            }
        }

        public ProductViewModel()
        {
            GetProduct();
            AddToCart = new Command(AddToCartFunc);

        }
    }
}
