using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Models
{
    /// <summary>
    /// 视频，趣事（不同视频，趣事需要分为不同栏目）
    /// </summary>
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string NewsName { get; set; }
        public string NewsDescription { get; set; }
        public string RelativeUrl { get; set; }
        public Image Images { get; set; }
        public Video Videos { get; set; }
        public Theme Themes { get; set; }
        public int ThemeID { get; set; }
        public int? NewFlag { get; set; }
        public DateTime? RecordTime { get; set; }
        public string RecordUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public String UpdateUser { get; set; }

    }
}
