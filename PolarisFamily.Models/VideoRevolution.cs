using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Models
{
    public class VideoRevolution
    {
        [Key]
        public int VideoRevolutionID { get; set; }
        public int VideoID { get; set; }
        public int? ProductID { get; set; }
        public int? NewsID { get; set; }
    }
}
