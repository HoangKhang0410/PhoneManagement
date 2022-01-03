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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        Product product;
        ObservableCollection<Product> _AllProducts;
        public Product PRODUCT
        {
            get { return product; }
            set { 
                product = value;
                OnPropertyChanged("PRODUCT");
            }
        }
        public ObservableCollection<Product> AllProducts
        {
            get { return _AllProducts; }
            set { _AllProducts = value;
                OnPropertyChanged("AllProducts");
            }
        }

        async void GetProduct()
        {
            HttpClient http = new HttpClient();
            var list = await http.GetStringAsync("http://192.168.0.106/webapidemo/api/ProductController/GetProductWithID?id=1");
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
        async void GetAllProducts()
        {
            HttpClient http = new HttpClient();
            var data = await http.GetStringAsync("http://www.wjbu-project.somee.com/api/ProductController/GetAllProducts");
            var allProducts = JsonConvert.DeserializeObject<List<Product>>(data);
            AllProducts = new ObservableCollection<Product>();
            for(int i = 0; i < allProducts.Count; i++)
            {
                AllProducts.Add(allProducts[i]);
            }
        }
        public ICommand ProductsCarousel { get; private set; }
        
        public ProductViewModel()
        {
            GetProduct();
            AllProducts = new ObservableCollection<Product>();
            ProductsCarousel = new Command(GetProduct);
            GetAllProducts();
        }
    }
}
