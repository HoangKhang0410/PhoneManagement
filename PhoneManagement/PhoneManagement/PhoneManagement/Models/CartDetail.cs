using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PhoneManagement.Models
{
    public class CartDetail
    {
        public int Cart_DetailID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int ProductQuanity { get; set; }
    }
}
