using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("Product") , MetadataType(typeof(ProductMetaData))]
    public class Product
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Category_ID { get; set; }
        public int Manufacture_ID { get; set; }
        public string Product_Short_Description { get; set; }
        public string Product_Long_Description { get; set; }
        public double Product_Price { get; set; }
        public string Product_Image { get; set; }
        public string Product_Size { get; set; }
        public string Product_Color { get; set; }
        public int Publication_Status { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }

        [ForeignKey("Manufacture_ID")]
        public virtual Manufacture Manufacture { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}