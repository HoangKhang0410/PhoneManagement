using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneManagement.Models
{
    public class OrderProductDetailModel
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductQuanity { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImg { get; set; }
        public string CategoryID { get; set; }
    }
}
