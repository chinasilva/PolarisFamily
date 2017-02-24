using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Models
{
    /// <summary>
    /// 栏目
    /// </summary>
    public class Theme
    {
        [Key]
        public int ThemeID { get; set; }
        public string ThemeName { get; set; }
        public string Description { get; set; }
        public DateTime? RecordTime { get; set; }
        public String RecordUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public String UpdateUser { get; set; }
    }
}
