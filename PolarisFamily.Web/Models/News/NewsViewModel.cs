using Microsoft.AspNetCore.Mvc.Rendering;
using PolarisFamily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Web.Models.News
{
    public class NewsViewModel
    {
        public Video Video; 
        public Image Image;
        public Theme Theme;
        public List<SelectListItem> VideoItem;
        public List<SelectListItem> ImageItem;
        public List<SelectListItem> ThemeItem;
        public PolarisFamily.Models.News News;
        public string ThemeName;

        public NewsViewModel()
        {
            News = new PolarisFamily.Models.News();
            Image = new Image();
            Video = new Video();
            Theme = new Theme();
            VideoItem = new List<SelectListItem>();
            ImageItem = new List<SelectListItem>();
            ThemeItem = new List<SelectListItem>();
        }
    }
}
