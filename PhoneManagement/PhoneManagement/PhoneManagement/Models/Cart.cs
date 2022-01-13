using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using PhoneManagement.Models;
using PhoneManagement.Views;
using Xamarin.Forms;

namespace PhoneManagement.Models
{
    public class Cart: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int CartID { get; set; }
        public int AccountID { get; set; }

        int CARTTOTAL;
        public int CartTotal
        {
            get
            {
                return CARTTOTAL;
            }
            set
            {
                CARTTOTAL = value;
                OnPropertyChanged("CartTotal");
            }
        }
        public string CartDate { get; set; }
    }
}
