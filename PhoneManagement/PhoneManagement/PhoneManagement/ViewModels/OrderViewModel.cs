using Newtonsoft.Json;
using PhoneManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;

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
            var chuoi = await http.GetStringAsync("link api");
            var dsOrder = JsonConvert.DeserializeObject<List<OrderModel>>(chuoi);

            for (int i = 0; i < dsOrder.Count; i++)
            {
               // Profile = dsOrder[i];
            }
        }


        //constructor
        public OrderViewModel()
        {
            GetOrderByAccountID();
        }

    }
}
