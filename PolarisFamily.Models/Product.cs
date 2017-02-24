using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public int BrandID { get; set; }
        public int? CategoryID { get; set; }
        public List<Image> Images { get; set; }
        public List<Video> Videos { get; set; }
        public string ProductName { get; set; }
        public string ThumbnailImage { get; set; }
        public float? Length { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public string UnitOfLength { get; set; }
        public float? Weight { get; set; }
        public string UnitOfWeight { get; set; }
        public float? UntiPrice { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public float? UnitPrice { get; set; }
    }
}
