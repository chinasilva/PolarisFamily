using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Models
{
    public class ImageRevolution
    {
        [Key]
        public int ImageRevolutionID { get; set; }
        public int ImageID { get; set; }
        public int? ProductID { get; set; }
        public int? NewsID { get; set; }
    }
}
