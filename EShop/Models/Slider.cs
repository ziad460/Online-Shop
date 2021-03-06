using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("Slider") , MetadataType(typeof(SliderMetaData))]
    public class Slider
    {
        public int Slider_ID { get; set; }
        public string Content_Name { get; set; }
        public string Content_Image { get; set; }
        public string Content_Describtion { get; set; }
        public int Publication_Status { get; set; }
    }
}