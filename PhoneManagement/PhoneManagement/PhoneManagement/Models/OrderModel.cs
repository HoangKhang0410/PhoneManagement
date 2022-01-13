using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PhoneManagement.Models
{
    public class OrderModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int OrderID;
        private int ShippingID;
        private int AccountID;
        private float OrderTotal;
        private int OrderStatus;
        private DateTime OrderDate;
        private string OrderNote;
       

        public int ORDERID
        {

            get { return OrderID; }
            set
            {
                OrderID = value;
                OnPropertyChanged("ORDERID");
            }
        }

        public int SHIPPINGID
        {

            get { return ShippingID; }
            set
            {
                ShippingID = value;
                OnPropertyChanged("SHIPPINGID");
            }
        }
        public int ACCOUNTID
        {

            get { return AccountID; }
            set
            {
                AccountID = value;
                OnPropertyChanged("ACCOUNTID");
            }
        }
        public float ORDERTOTAL
        {

            get { return OrderTotal; }
            set
            {
                OrderTotal = value;
                OnPropertyChanged("ORDERTOTAL");
            }
        }
        public int ORDERSTATUS
        {

            get { return OrderStatus; }
            set
            {
                OrderStatus = value;
                OnPropertyChanged("ORDERSTATUS");
            }
        }
        public DateTime ORDERDATE
        {

            get { return OrderDate; }
            set
            {
                OrderDate = value;
                OnPropertyChanged("ORDERDATE");
            }
        }
        public string ORDERNOTE
        {

            get { return OrderNote; }
            set
            {
                OrderNote = value;
                OnPropertyChanged("ORDERNOTE");
            }
        }

    }
}
