using System.Collections.Generic;
using PolarisFamily.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PolarisFamily.Web.Models.Orders
{
    public class OrderConfirmModel
    {
        public Order OrderItem { get; set; }
        public float? TotalAmount { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<SelectListItem> ShipAddresses { get; set; }
        public string IDList { get; set; }
        public string ProductID { get; set; }
        public int ProductAmount { get; set; }
    }
}
