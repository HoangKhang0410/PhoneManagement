using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneManagement.Models
{
    public class OrderDetailModel
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int ProductQuanity { get; set; }
    }
}
