using EShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop
{
    public class CategoryMetaData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_ID { get; set; }
        [Required, MaxLength(50)]
        public string Category_Name { get; set; }
    }
    public class OrderMetaData
    {
        [Key]
        public int Order_ID { get; set; }
    }
    public class OrderDetailsMetaData
    {
        [Key]
        public int OrderDetails_ID { get; set; }
        [MaxLength(50) , Required]
        public string Product_Name { get; set; }
    }
    public class ProductMetaData
    {
        [Key]
        public int Product_ID { get; set; }
        [Required , MaxLength(50) , Display(Name = "Name")]
        public string Product_Name { get; set; }
        [Required , Display(Name = "Price")]
        public double Product_Price { get; set; }
        [Required, Display(Name = "Image")]
        public string Product_Image { get; set; }
        [Required, Display(Name = "Size")]
        public string Product_Size { get; set; }
        [Required , Display(Name = "Color")]
        public string Product_Color { get; set; }
        [Display(Name = "Short Description")]
        public string Product_Short_Description { get; set; }
        [Display(Name = "Long Description")]
        public string Product_Long_Description { get; set; }
        [Display(Name = "Category")]
        public int Category_ID { get; set; }
        [Display(Name = "Manufacture")]
        public int Manufacture_ID { get; set; }
    }
    public class ManufactureMetaData
    {
        [Key]
        public int Manufacture_ID { get; set; }
        [Required , MaxLength(50)]
        public string Manufacture_Name { get; set; }
    }
    public class PaymentMetaData
    {
        [Key]
        public int Payment_ID { get; set; }
    }
    public class ShippingMetaData
    {
        [Key]
        public int Shipping_ID { get; set; }
        [Required , EmailAddress]
        public string Shipping_Email { get; set; }
        [Required , MaxLength(50   )]
        public string Shipping_Name { get; set; }
        
        public ShippingAddress Shipping_Address { get; set; }
    }
    public class SliderMetaData
    {
        [Key]
        public int Slider_ID { get; set; }
        [Required , MaxLength(50)]
        public string Content_Name { get; set; }
        [Required , MaxLength(50)]
        public string Content_Image { get; set; }
    }

}