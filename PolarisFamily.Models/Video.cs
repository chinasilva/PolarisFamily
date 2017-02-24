using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Models
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        public int? NewsID { get; set; }
        public string VideoName { get; set; }
        public string Description { get; set; }
        public string VideoRelativeUrl { get; set; }
        public DateTime? RecordTime { get; set; }
        public String RecordUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public String UpdateUser { get; set; }
    }
}
