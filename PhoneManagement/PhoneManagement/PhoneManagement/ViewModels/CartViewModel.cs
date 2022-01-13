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

        ObservableCollection<CartProduct> cartProducts;
        public ObservableCollection<CartProduct> CARTPRODUCTS
        {
            get { return cartProducts; }
            set
            {
                cartProducts = value;
                OnPropertyChanged("CARTPRODUCTS");
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

        ObservableCollection<Shipping> listAddress;
        public ObservableCollection<Shipping> LISTADDRESS
        {
            get
            {
                return listAddress;
            }
            set
            {
                listAddress = value;
                OnPropertyChanged("LISTADDRESS");
            }
        }
        async void GetCart()
        {
            HttpClient http = new HttpClient();
            var list = await http.GetStringAsync("http://192.168.1.5/webapidemo/api/CartController/GetCart?accountID=1");
            var listConvert = JsonConvert.DeserializeObject<List<Cart>>(list);
            CART = new Cart();
            if (listConvert.Count > 0)
            {
                CART = listConvert[0];
            }
            //else
            //{
            //    await http.GetStringAsync("http://192.168.1.5/webapidemo/api/CartController/CreateCart?accountID=1");
            //}
        }

        async void RenderCartPage()
        {
            HttpClient http = new HttpClient();
            var list = await http.GetStringAsync("http://192.168.1.5/webapidemo/api/CartController/GetCartDetail?accountID=1");
            var listConvert = JsonConvert.DeserializeObject<List<CartDetail>>(list);
            CARTPRODUCTS = new ObservableCollection<CartProduct>();
            for (int i = 0; i < listConvert.Count; i++)
            {
                var pID = listConvert[i].ProductID;
                var product = await http.GetStringAsync("http://192.168.1.5/webapidemo/api/ProductController/GetProductWithID?id=" + pID);
                var productConvert = JsonConvert.DeserializeObject<List<Product>>(product);
                CartProduct temp = new CartProduct
                {
                    CARTDETAILID = listConvert[i].Cart_DetailID,
                    CARTID = listConvert[i].CartID,
                    PRODUCTID = listConvert[i].ProductID,
                    PRODUCTQUANITY = listConvert[i].ProductQuanity,
                    PRODUCTNAME = productConvert[0].ProductName,
                    PRODUCTIMG = productConvert[0].ProductImg,
                    PRODUCTPRICE = productConvert[0].ProductPrice,
                    PRODUCTSTATUS = productConvert[0].ProductStatus,
                    CATEGORYID = productConvert[0].CategoryID,
                };
                CARTPRODUCTS.Add(temp);
            }
        }
        public ICommand plusCommand { get; set; }
        public ICommand minusCommand { get; set; }

        async void plusFunc(object cartDetailID)
        {
            for (int i = 0; i < CARTPRODUCTS.Count; i++)
            {
                if (CARTPRODUCTS[i].CARTDETAILID.ToString() == cartDetailID.ToString())
                {
                    CARTPRODUCTS[i].PRODUCTQUANITY++;
                    CART.CartTotal += int.Parse(CARTPRODUCTS[i].PRODUCTPRICE.ToString());
                    HttpClient http = new HttpClient();
                    var list = await http.GetStringAsync("http://192.168.1.5/webapidemo/api/CartController/UpdateCart?cartID=" + CART.CartID + "&total=" + CART.CartTotal + "&cartDetailID=" + CARTPRODUCTS[i].CARTDETAILID + "&quanity=" + CARTPRODUCTS[i].PRODUCTQUANITY);
                }
            }
            
        }
        async void minusFunc(object cartDetailID)
        {
            HttpClient http = new HttpClient();
            
            for (int i = 0; i < CARTPRODUCTS.Count; i++)
            {
                if (CARTPRODUCTS[i].CARTDETAILID.ToString() == cartDetailID.ToString())
                {
                    if (CARTPRODUCTS[i].PRODUCTQUANITY - 1 <= 0)
                    {
                        CART.CartTotal -= int.Parse(CARTPRODUCTS[i].PRODUCTPRICE.ToString());

                        var list = await http.GetStringAsync("http://192.168.1.5/webapidemo/api/CartController/DeleteProductInCart?pID=" + CARTPRODUCTS[i].PRODUCTID + "&cartDetailID=" + CARTPRODUCTS[i].CARTDETAILID + "&total=" + CART.CartTotal + "&cartID=" + CART.CartID);
                        CARTPRODUCTS.Remove(CARTPRODUCTS[i]);
                    }
                    else
                    {
                        CARTPRODUCTS[i].PRODUCTQUANITY--;
                        CART.CartTotal -= int.Parse(CARTPRODUCTS[i].PRODUCTPRICE.ToString());
                        var list = await http.GetStringAsync("http://192.168.1.5/webapidemo/api/CartController/UpdateCart?cartID=" + CART.CartID + "&total=" + CART.CartTotal + "&cartDetailID=" + CARTPRODUCTS[i].CARTDETAILID + "&quanity=" + CARTPRODUCTS[i].PRODUCTQUANITY);
                    }
                }
            }
        }
        async void GetShipping()
        {
            HttpClient http = new HttpClient();
            var list = await http.GetStringAsync("http://192.168.1.5/webapidemo/api/ShippingController/GetListShipping?accountID=1");
            var listConvert = JsonConvert.DeserializeObject<List<Shipping>>(list);
            LISTADDRESS = new ObservableCollection<Shipping>();
            for (int i = 0; i < listConvert.Count; i++)
            {
                LISTADDRESS.Add(listConvert[i]);
            }
        }

        public CartViewModel()
        {
            RenderCartPage();
            GetCart();
            plusCommand = new Command(plusFunc);
            minusCommand = new Command(minusFunc);
            LISTADDRESS = new ObservableCollection<Shipping>();
            GetShipping();
        }
    }
}
