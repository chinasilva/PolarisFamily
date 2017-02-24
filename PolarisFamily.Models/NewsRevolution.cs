using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Models
{
    public class NewsRevolution
    {
        [Key]
        public int newsRevolationID { get; set; }
        public int newsID { get; set; }
        public int themeID { get; set; }

    }
}
