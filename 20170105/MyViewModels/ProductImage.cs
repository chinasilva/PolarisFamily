using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Web.Models.MyViewModels
{
    public class ProductImage
    {
        public int ImageID { get; set; }
        public Guid ProductID { get; set; }
        public string RelativeUrl { get; set; }
        public string Comments { get; set; }
    }
}
