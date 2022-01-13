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
        ObservableCollection<Product> _AllProducts1;
        ObservableCollection<Product> _AllProducts2;
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
        public ObservableCollection<Product> AllProducts1
        {
            get { return _AllProducts1; }
            set
            {
                _AllProducts1 = value;
                OnPropertyChanged("AllProducts1");
            }
        }
        public ObservableCollection<Product> AllProducts2
        {
            get { return _AllProducts2; }
            set
            {
                _AllProducts2 = value;
                OnPropertyChanged("AllProducts2");
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
        async void AddToCartFunc(string pID)
        {
            HttpClient http = new HttpClient();
            var oke = await http.GetStringAsync("http://192.168.0.106/webapidemo/api/CartController/AddToCart?accountID=1" + "&pID=" + pID);
            //bool succeed = false;
            //Boolean.TryParse(oke, out succeed);
            //if (succeed)
            //{

            //}
            await Application.Current.MainPage.DisplayAlert("Thong bao", "Them san pham vao gio hang thanh cong", "OK");
        }

        async void GetAllProducts()
        {
            HttpClient http = new HttpClient();
            var data = await http.GetStringAsync("http://www.wjbu-project.somee.com/api/ProductController/GetAllProducts");
            var allProducts = JsonConvert.DeserializeObject<List<Product>>(data);
            AllProducts = new ObservableCollection<Product>();
            AllProducts1 = new ObservableCollection<Product>();
            AllProducts2 = new ObservableCollection<Product>();
            for (int i = 0; i < allProducts.Count; i++)
            {
                if(i % 2 ==0)
                {
                    AllProducts1.Add(allProducts[i]);
                }
                else
                {
                    AllProducts2.Add(allProducts[i]);
                }
            }
        }
        ObservableCollection<Category> listCate;
        public ObservableCollection<Category> LISTCATE
        {
            get { return listCate; }
            set
            {
                listCate = value;
                OnPropertyChanged("LISTCATE");
            }
        }

        void CategoryListInit()
        {
            LISTCATE = new ObservableCollection<Category>();
            LISTCATE.Add(new Category { CategoryName = "Iphone", CategoryImage = "https://rubee.com.vn/admin/webroot/upload/image//images/tin-tuc/logo-iphone-2.jpg" });
            LISTCATE.Add(new Category { CategoryName = "Oppo", CategoryImage = "https://cdn.tgdd.vn/Files/2019/03/12/1154295/oppo-logo-old_600x277.jpg" });
            LISTCATE.Add(new Category { CategoryName = "Iphone", CategoryImage = "https://rubee.com.vn/admin/webroot/upload/image//images/tin-tuc/logo-iphone-2.jpg" });
            LISTCATE.Add(new Category { CategoryName = "Iphone", CategoryImage = "https://rubee.com.vn/admin/webroot/upload/image//images/tin-tuc/logo-iphone-2.jpg" });
        }

        public ICommand ShowCategoryProductCommand { get; set; }

        async void ShowCategoryProduct(object CategoryID)
        {
            HttpClient http = new HttpClient();
            var data = await http.GetStringAsync("http://www.wjbu-project.somee.com/api/ProductController/GetProductByCategoryID?cID=" + CategoryID.ToString());
            var allProducts = JsonConvert.DeserializeObject<List<Product>>(data);
            AllProducts1 = new ObservableCollection<Product>();
            AllProducts2 = new ObservableCollection<Product>();
            //AllProducts1.Clear();
            //AllProducts2.Clear();
            for (int i = 0; i < allProducts.Count; i++)
            {
                if (i % 2 == 0)
                {
                    AllProducts1.Add(allProducts[i]);
                }
                else
                {
                    AllProducts2.Add(allProducts[i]);
                }
            }
        }
        public ICommand SearchProductCommand { get; set; }

        async void SearchProduct(object ProductName)
        {
            HttpClient http = new HttpClient();
            var data = await http.GetStringAsync("http://www.wjbu-project.somee.com/api/ProductController/SearchProduct?keyword=" + ProductName.ToString());
            var allProducts = JsonConvert.DeserializeObject<List<Product>>(data);
            AllProducts1 = new ObservableCollection<Product>();
            AllProducts2 = new ObservableCollection<Product>();
            //AllProducts1.Clear();
            //AllProducts2.Clear();
            for (int i = 0; i < allProducts.Count; i++)
            {
                if (i % 2 == 0)
                {
                    AllProducts1.Add(allProducts[i]);
                }
                else
                {
                    AllProducts2.Add(allProducts[i]);
                }
            }
        }

        public ProductViewModel()
        {
            GetProduct();
            //AllProducts = new ObservableCollection<Product>();
            AllProducts1 = new ObservableCollection<Product>();
            AllProducts2 = new ObservableCollection<Product>();
            LISTCATE = new ObservableCollection<Category>();
            CategoryListInit();
            GetAllProducts();
            //AddToCart = new Command<string>(AddToCartFunc);
            ShowCategoryProductCommand = new Command(ShowCategoryProduct);
            SearchProductCommand = new Command(SearchProduct);
        }
    }
}
