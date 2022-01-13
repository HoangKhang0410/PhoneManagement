using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PhoneManagement.Models
{
    public class Shipping: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int ShippingID;
        private string ShippingName;
        private int AccountID;
        private string ShippingAddress;
        private string ShippingPhone;



        public int SHIPPINGID
        {

            get { return ShippingID; }
            set
            {
                ShippingID = value;
                OnPropertyChanged("SHIPPINGID");
            }
        }

        public string SHIPPINGNAME
        {

            get { return ShippingName; }
            set
            {
                ShippingName = value;
                OnPropertyChanged("SHIPPINGNAME");
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
        public string SHIPPINGADDRESS
        {

            get { return ShippingAddress; }
            set
            {
                ShippingAddress = value;
                OnPropertyChanged("SHIPPINGADDRESS");
            }
        }
        public string SHIPPINGPHONE
        {

            get { return ShippingPhone; }
            set
            {
                ShippingPhone = value;
                OnPropertyChanged("SHIPPINGPHONE");
            }
        }
    }
}
