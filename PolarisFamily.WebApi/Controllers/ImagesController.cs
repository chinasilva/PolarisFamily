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
    public class ImagesController : Controller
    {
        private readonly IImageRepository _imageRepository;
        private readonly WebApiSettings _settings;
        private PolarisFamilyDbContext _context;
        public ImagesController(IImageRepository imageRepository,
             IOptions<WebApiSettings> settings,PolarisFamilyDbContext Context)
        {
            _context = Context;
            _imageRepository = imageRepository;
            _settings = settings.Value;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string keyword, [FromQuery] int page, [FromQuery] int pagesize)
        {
            if (0 == pagesize)
                return ResponseHelper.BadRequest();

            IEnumerable<Image> images = await _imageRepository.GetImageAsync(keyword, pagesize, page);

            //foreach (Image i in images)
            JsonResult result = new JsonResult(images);
            return result;
        }
        [HttpGet("{imageID}")]
        public async Task<ActionResult> Get([FromRoute] int imageID)
        {
            if (string.IsNullOrEmpty(imageID.ToString()))
                return ResponseHelper.BadRequest();
            Image image = await _imageRepository.GetAsync(imageID);
            JsonResult result = new JsonResult(image);
            return result;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Image value)
        {
            if (null == value || string.IsNullOrEmpty( value.ImageID.ToString()))
                return ResponseHelper.BadRequest();

            // 先查看当前保存的数据中是否有这么一个产品信息
            var image = await _imageRepository.GetAsync(value.ImageID);
            if (null == image)
                await _imageRepository.AddAsync(value);
            else
            {
                image.RelativeUrl= value.RelativeUrl;
                image.ImageName = value.ImageName;
                image.Description = value.Description;
                await _imageRepository.UpdateAsync(image);
            }

            return Ok();
        }
        // PUT api/values/5
        [HttpPut("{imageID}")]
        public async Task<IActionResult> Put([FromRoute] int imageID, [FromBody] Image value)
        {
            if (null == value || string.IsNullOrEmpty( value.ImageID.ToString()))
                return ResponseHelper.BadRequest();

            // 先查看当前保存的数据中是否有这么一个产品信息
            var image = await _imageRepository.GetAsync(value.ImageID);
            if (null == image)
                await _imageRepository.AddAsync(value);
            else
            {

                image.RelativeUrl= value.RelativeUrl;
                image.ImageName= value.ImageName;
                image.Description = value.Description;
                
                await _imageRepository.UpdateAsync(image);
            }
            return Ok();
        }
        // DELETE api/values/5
        [HttpDelete("{imageID}")]
        public async Task<IActionResult> Delete(int imageID)
        {
            if (string.IsNullOrEmpty(imageID.ToString()))
                return ResponseHelper.BadRequest();
            await _imageRepository.DeleteAsync(imageID);
            return Ok();
        }


        [HttpGet, Route("getall")]
        public IList<Image> GetAll()
        {
            var lst = _context.Images.Take(10).ToList();
            return lst;
        }

        [HttpGet, Route("getslider")]
        public async Task<IActionResult> GetSlider()
        {
            var lst =await _imageRepository.GetSliderAsync();
            JsonResult result = new JsonResult(lst);
            return result;
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
