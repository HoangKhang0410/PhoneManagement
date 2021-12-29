using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using PhoneManagement.Models;

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
        public ProductViewModel()
        {
            GetProduct();
    
        }
    }
}
