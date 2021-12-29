using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PhoneManagement.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductQuanity { get; set; }
        public float ProductPrice { get; set; }
        public int ProductStatus { get; set; }
        public string ProductImg { get; set; }
        public int CategoryID { get; set; }
    }
}
