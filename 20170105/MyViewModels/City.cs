using System.ComponentModel.DataAnnotations;

namespace PolarisFamily.Web.Models.MyViewModels
{
    public class City
    {
      [Key]
      public int ID { get; set; }
      public int CityIndex { get; set; }
      public int ProvinceID { get; set; }
      public string Name { get; set; }
    }
}
