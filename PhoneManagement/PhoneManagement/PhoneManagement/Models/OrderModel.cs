using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneManagement.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int ShippingID { get; set; }
        public int AccountID { get; set; }
        public float OrderTotal { get; set; }
        public int OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNote { get; set; }


    }
}
