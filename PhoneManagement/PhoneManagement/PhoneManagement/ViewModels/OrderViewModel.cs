using Newtonsoft.Json;
using PhoneManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneManagement.ViewModels
{
    class OrderViewModel: INotifyPropertyChanged
    {
        // liên quan đến việc update dữ liệu
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ObservableCollection<OrderModel> _AllOrders;
        public ObservableCollection<OrderModel> AllOrders
        {
            get { return _AllOrders; }
            set
            {
                _AllOrders = value;
                OnPropertyChanged("AllOrders");
            }
        }
        ObservableCollection<OrderProductModel> _AllOrdersProduct;
        public ObservableCollection<OrderProductModel> AllOrdersProduct
        {
            get { return _AllOrdersProduct; }
            set
            {
                _AllOrdersProduct = value;
                OnPropertyChanged("AllOrdersProduct");
            }
        }
        ObservableCollection<OrderProductDetailModel> _AllDetailOrders;
        public ObservableCollection<OrderProductDetailModel> AllDetailOrders
        {
            get { return _AllDetailOrders; }
            set
            {
                _AllDetailOrders = value;
                OnPropertyChanged("AllDetailOrders");
            }
        }
        //khởi tạo đối tượng và property
        private OrderModel order;
        public OrderModel Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }



        //các hàm xử lý
        async void GetOrderByAccountID()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://wjbu-project.somee.com/api/OrderController/GetListOrder?accountID=1");
            var dsOrder = JsonConvert.DeserializeObject<List<OrderModel>>(chuoi);
            AllOrdersProduct = new ObservableCollection<OrderProductModel>();
            for (int i = 0; i < dsOrder.Count; i++)
            {
                var chuoi1 = await http.GetStringAsync("http://wjbu-project.somee.com/api/OrderController/GetListOrderDetail?orderID=" + dsOrder[i].ORDERID.ToString());
                var dsOrderDetail = JsonConvert.DeserializeObject<List<OrderDetailModel>>(chuoi1);
                var chuoi2 = await http.GetStringAsync("http://wjbu-project.somee.com/api/ProductController/GetProductWithID?id=" + dsOrderDetail[0].PRODUCTID.ToString());
                var dsProduct = JsonConvert.DeserializeObject<List<Product>>(chuoi2);
                string status = "";
                if (dsOrder[i].ORDERSTATUS.ToString() == "0")
                {
                    status = "Đang xử lý";
                }
                else
                {
                    status = "Hoàn thành";
                }
                OrderProductModel tempt = new OrderProductModel
                {
                    OrderID = dsOrder[i].ORDERID,
                    OrderDate = dsOrder[i].ORDERDATE,
                    OrderTotal = dsOrder[i].ORDERTOTAL,
                    OrderStatus = status,
                    ProductID = dsOrderDetail[0].PRODUCTID,
                    ProductQuanity = dsOrderDetail[0].PRODUCTQUANITY,
                    ProductImg = dsProduct[0].ProductImg,
                    ProductName = dsProduct[0].ProductName,
                    ProductPrice = dsProduct[0].ProductPrice
                };
                AllOrdersProduct.Add(tempt);
            }
        }


        public ICommand ShowDetailOrderCommand { get;private set; }

        async void ShowDetailOrderFunction(object x)
        {
            HttpClient http = new HttpClient();
            var chuoi5 = await http.GetStringAsync("http://wjbu-project.somee.com/api/OrderController/GetListOrder?accountID=1");
            var dsOrder = JsonConvert.DeserializeObject<List<OrderModel>>(chuoi5);
            Order = dsOrder[0];
            
            var chuoi = await http.GetStringAsync("http://wjbu-project.somee.com/api/OrderController/GetListOrderDetail?orderID=" + x.ToString());
            var dsOrderDetail = JsonConvert.DeserializeObject<List<OrderDetailModel>>(chuoi);
            AllDetailOrders = new ObservableCollection<OrderProductDetailModel>();
            for (int i = 0; i < dsOrderDetail.Count; i++)
            {
                var chuoi2 = await http.GetStringAsync("http://wjbu-project.somee.com/api/ProductController/GetProductWithID?id=" + dsOrderDetail[i].PRODUCTID.ToString());
                var dsProduct = JsonConvert.DeserializeObject<List<Product>>(chuoi2);
                var category = "";
                switch(dsProduct[0].CategoryID.ToString())
                {
                    case "1":
                        category = "Samsung";
                        break;
                    case "2":
                        category = "Iphone";
                        break;
                    case "3":
                        category = "Xiaomi";
                        break;
                    case "4":
                        category = "Oppo";
                        break;
                }
               
                OrderProductDetailModel tempt = new OrderProductDetailModel
                {
                    ProductID = dsOrderDetail[i].PRODUCTID,
                    ProductQuanity = dsOrderDetail[i].PRODUCTQUANITY,
                    ProductImg = dsProduct[0].ProductImg,
                    ProductName = dsProduct[0].ProductName,
                    ProductPrice = dsProduct[0].ProductPrice,
                    CategoryID = category

                };
                AllDetailOrders.Add(tempt);
            }
            await Application.Current.MainPage.Navigation.PushAsync(new Views.OrderDetailPage(AllDetailOrders, Order));
        }


        //constructor
        public OrderViewModel()
        {
            AllOrdersProduct = new ObservableCollection<OrderProductModel>();
            GetOrderByAccountID();
            ShowDetailOrderCommand = new Command(ShowDetailOrderFunction);
        }

    }
}
