using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolarisFamily.Data;
using PolarisFamily.Models;
using System.Threading.Tasks;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.Web.Models;

namespace PolarisFamily.Web.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        // GET: Brands
        [Route("/Brands/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            BrandModelView bmv = new BrandModelView();
            bmv.Brand = await _brandRepository.GetAsync(id);
            bmv.Products = await _brandRepository.GetProductsAsync(id, "", 50, 0);
            return View(bmv);
        }
    }
}