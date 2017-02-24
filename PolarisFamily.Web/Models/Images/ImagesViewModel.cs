using Microsoft.AspNetCore.Mvc.Rendering;
using PolarisFamily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Web.Models.Images
{
    public class ImagesViewModel
    {
        public Image  Image;
        public List<SelectListItem> ImageSelect;
        public ImagesViewModel()
        {
            ImageSelect = new List<SelectListItem>();
        }
    }
}
