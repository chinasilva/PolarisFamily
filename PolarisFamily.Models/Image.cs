using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public int? ProductID { get; set; }
        public int? NewsID { get; set; }
        public string ImageName { get; set; }
        public string RelativeUrl { get; set; }
        public string Comments { get; set; }
        public string Description { get; set; }
        public DateTime? RecordTime { get; set; }
        public string RecordUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public String UpdateUser { get; set; }
    }
}
