using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    public class ShippingAddress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
    }
}