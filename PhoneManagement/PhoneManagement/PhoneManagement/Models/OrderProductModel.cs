using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PhoneManagement.Models
{
    public class OrderProductModel 
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductQuanity { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImg { get; set; }
        public int OrderID { get; set; }
        public float OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
