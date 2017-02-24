using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolarisFamily.Data;
using PolarisFamily.Models;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.WebApi.Utils;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PolarisFamily.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageRepository _ImageRepository;
        private readonly WebApiSettings _settings;
        private PolarisFamilyDbContext _context;
        public ProductsController(IProductRepository productRepository,
            IImageRepository imageRepository, IOptions<WebApiSettings> settings, PolarisFamilyDbContext Context)
        {
            _context = Context;
            _productRepository = productRepository;
            _ImageRepository = imageRepository;
            _settings = settings.Value;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string keyword, [FromQuery] int page, [FromQuery] int pagesize)
        {
            if (0 == pagesize)
                return ResponseHelper.BadRequest();

            IEnumerable<Product> products = await _productRepository.GetProductsAsync(keyword, pagesize, page);
            foreach (Product p in products)
                p.ThumbnailImage = _settings.HostName + p.ThumbnailImage;
            JsonResult result = new JsonResult(products);
            return result;
        }

        [HttpGet("{productID}")]
        public async Task<ActionResult> Get([FromRoute] int productID)
        {
            if (string.IsNullOrEmpty(productID.ToString()))
                return ResponseHelper.BadRequest();
            Product product = await _productRepository.GetAsync(productID);
            product.ThumbnailImage = _settings.HostName + product.ThumbnailImage;
            product.Images= await _ImageRepository.GetProductImages(productID);
            foreach (Image img in product.Images)
                img.RelativeUrl = _settings.HostName + img.RelativeUrl;
            JsonResult result = new JsonResult(product);
            return result;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product value)
        {
            if (null == value || string.IsNullOrEmpty(value.ProductID.ToString()))
                return ResponseHelper.BadRequest();

            // 先查看当前保存的数据中是否有这么一个产品信息
            var product = await _productRepository.GetAsync(value.ProductID);
            if (null == product)
                await _productRepository.AddAsync(value);
            else
            {
                product.BrandID = value.BrandID;
                product.CategoryID = value.CategoryID;
                product.CreatedTime = value.CreatedTime;
                product.Currency = value.Currency;
                product.Description = value.Description;
                product.Height = value.Height;
               // product.LastUpdateTime = value.LastUpdateTime;
                product.Length = value.Length;
                product.ProductName = value.ProductName;
                product.ThumbnailImage = value.ThumbnailImage;
                product.UnitOfLength = value.UnitOfLength;
                product.UnitOfWeight = value.UnitOfWeight;
                product.Weight = value.Width;
                product.Width = value.Width;
                await _productRepository.UpdateAsync(product);
            }

            return Ok();
        }
        // PUT api/values/5
        [HttpPut("{productID}")]
        public async Task<IActionResult> Put([FromRoute] Guid productID, [FromBody] Product value)
        {
            if (null == value 
                || string.IsNullOrEmpty( value.ProductID.ToString()))
                return ResponseHelper.BadRequest();

            // 先查看当前保存的数据中是否有这么一个产品信息
            var product = await _productRepository.GetAsync(value.ProductID);
            if (null == product)
                await _productRepository.AddAsync(value);
            else
            {
                product.BrandID = value.BrandID;
                product.CategoryID = value.CategoryID;
                product.CreatedTime = value.CreatedTime;
                product.Currency = value.Currency;
                product.Description = value.Description;
                product.Height = value.Height;
               // product.LastUpdateTime = value.LastUpdateTime;
                product.Length = value.Length;
                product.ProductName = value.ProductName;
                product.ThumbnailImage = value.ThumbnailImage;
                product.UnitOfLength = value.UnitOfLength;
                product.UnitOfWeight = value.UnitOfWeight;
                product.Weight = value.Width;
                product.Width = value.Width;
                await _productRepository.UpdateAsync(product);
            }
            return Ok();
        }
        // DELETE api/values/5
        [HttpDelete("{productID}")]
        public async Task<IActionResult> Delete(int productID)
        {
            if (string.IsNullOrEmpty(productID.ToString()))
                return ResponseHelper.BadRequest();
            await _productRepository.DeleteAsync(productID);
            return Ok();
        }


        [HttpGet, Route("getall")]
        public IList<Product> GetAll()
        {
            var lst = _context.Products.Take(10).ToList();
            return lst;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}
