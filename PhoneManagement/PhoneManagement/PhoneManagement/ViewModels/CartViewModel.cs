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
    class CartViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ObservableCollection<CartDetail> listCartDetail;
        ObservableCollection<Product> listProduct;
        Cart cart;

        public ObservableCollection<CartDetail> LISTCARTDETAIL
        {
            get { return listCartDetail; }
            set
            {
                listCartDetail = value;
                OnPropertyChanged("LISTCARTDETAIL");
            }
        }

        public ObservableCollection<Product> LISTPRODUCT
        {
            get { return listProduct; }
            set
            {
                listProduct = value;
                OnPropertyChanged("LISTPRODUCT");
            }
        }

        public Cart CART
        {
            get { return cart; }
            set
            {
                cart = value;
                OnPropertyChanged("CART");
            }
        }
        async void GetCart()
        {
            HttpClient http = new HttpClient();
            var list = await http.GetStringAsync("http://192.168.0.106/webapidemo/api/CartController/GetCart?accountID=1");
            var listConvert = JsonConvert.DeserializeObject<List<Cart>>(list);
            CART = new Cart();
            CART = listConvert[0];
        }

        async void RenderCartPage()
        {
            HttpClient http = new HttpClient();
            var list = await http.GetStringAsync("http://192.168.0.106/webapidemo/api/CartController/GetCartDetail?accountID=1");
            var listConvert = JsonConvert.DeserializeObject<List<CartDetail>>(list);
            LISTCARTDETAIL = new ObservableCollection<CartDetail>();
            LISTPRODUCT = new ObservableCollection<Product>();
            for (int i = 0; i < listConvert.Count; i++)
            {
                LISTCARTDETAIL.Add(listConvert[i]);
            }
            for (int j = 0; j < LISTCARTDETAIL.Count; j++)
            {
                var product = await http.GetStringAsync("http://192.168.0.106/webapidemo/api/ProductController/GetProductWithID?id=" + LISTCARTDETAIL[j].ProductID);
                var productConvert = JsonConvert.DeserializeObject<List<Product>>(product);
                LISTPRODUCT.Add(productConvert[0]);
            }
        }

        public CartViewModel()
        {
            //RenderCartPage();
            //GetCart();
        }
    }
}
