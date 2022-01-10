using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using PhoneManagement.Models;
using PhoneManagement.Views;
using Xamarin.Forms;

namespace PhoneManagement.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int AccountID { get; set; }
        public int CartTotal { get; set; }
        public string CartDate { get; set; }
    }
}
