﻿using System.Collections.Generic;

namespace PolarisFamily.Web.Models.MyViewModels
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
