using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("Manufacture") , MetadataType(typeof(ManufactureMetaData))]
    public class Manufacture
    {
        public int Manufacture_ID { get; set; }
        public string Manufacture_Name { get; set; }
        public string Manufacture_Description { get; set; }
        public int Publication_Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}