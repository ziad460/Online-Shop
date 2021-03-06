using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("OrderDetails") , MetadataType(typeof(OrderDetailsMetaData))]
    public class OrderDetails
    {
        
        public int OrderDetails_ID { get; set; }
        public int Order_ID { get; set; }
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public  double Product_Price { get; set; }
        public int Product_Sales_Quantity { get; set; }
        public double Total_price { get; set; }

        [ForeignKey("Order_ID")]
        public virtual Order Order { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }

    }
}