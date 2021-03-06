using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("Shipping") , MetadataType(typeof(ShippingMetaData))]
    public class Shipping
    {
        public int Shipping_ID { get; set; }
        public string Shipping_Email { get; set; }
        public string Shipping_Name { get; set; }
        public ShippingAddress Shipping_Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}