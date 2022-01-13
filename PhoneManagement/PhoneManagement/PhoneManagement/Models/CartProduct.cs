using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using PhoneManagement.Models;
using PhoneManagement.Views;
using Xamarin.Forms;
namespace PhoneManagement.Models
{
   public class CartProduct:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        int Cart_DetailID;
        public int CARTDETAILID
        {
            get
            {
                return Cart_DetailID;
            }
            set
            {
                Cart_DetailID = value;
                OnPropertyChanged("CARTDETAILID");
            }
        }

        int CartID;
        public int CARTID
        {
            get
            {
                return CartID;
            }
            set
            {
                CartID = value;
                OnPropertyChanged("CARTID");
            }
        }
        int ProductID;
        public int PRODUCTID
        {
            get
            {
                return ProductID;
            }
            set
            {
                ProductID = value;
                OnPropertyChanged("PRODUCTID");
            }
        }

        int ProductQuanity;
        public int PRODUCTQUANITY
        {
            get
            {
                return ProductQuanity;
            }
            set
            {
                ProductQuanity = value;
                OnPropertyChanged("PRODUCTQUANITY");
            }
        }

        string ProductName;
        public string PRODUCTNAME
        {
            get
            {
                return ProductName;
            }
            set
            {
                ProductName = value;
                OnPropertyChanged("PRODUCTNAME");
            }
        }

        float ProductPrice;
        public float PRODUCTPRICE
        {
            get
            {
                return ProductPrice;
            }
            set
            {
                ProductPrice = value;
                OnPropertyChanged("PRODUCTPRICE");
            }
        }
        int ProductStatus;
        public int PRODUCTSTATUS
        {
            get
            {
                return ProductStatus;
            }
            set
            {
                ProductStatus = value;
                OnPropertyChanged("PRODUCTSTATUS");
            }
        }
        string ProductImg;
        public string PRODUCTIMG
        {
            get
            {
                return ProductImg;
            }
            set
            {
                ProductImg = value;
                OnPropertyChanged("PRODUCTIMG");
            }
        }
        int CategoryID;
        public int CATEGORYID
        {
            get
            {
                return CategoryID;
            }
            set
            {
                CategoryID = value;
                OnPropertyChanged("CATEGORYID");
            }
        }

    }
}
