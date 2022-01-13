using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PhoneManagement.Models
{
    public class OrderDetailModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int OrderDetailID;
        private int ProductID;
        private int OrderID;
        private int ProductQuanity;

        public int ORDERDETAILID
        {
            get { return OrderDetailID; }
            set
            {
                OrderDetailID = value;
                OnPropertyChanged("ORDERDETAILID");
            }
        }
        public int PRODUCTID
        {
            get { return ProductID; }
            set
            {
                ProductID = value;
                OnPropertyChanged("PRODUCTID");
            }
        }
        public int ORDERID
        {
            get { return OrderID; }
            set
            {
                OrderID = value;
                OnPropertyChanged("ORDERID");
            }
        }
        public int PRODUCTQUANITY
        {
            get { return ProductQuanity; }
            set
            {
                ProductQuanity = value;
                OnPropertyChanged("PRODUCTQUANITY");
            }
        }

    }
}
