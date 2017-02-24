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
    public class VideosController : Controller
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IImageRepository _imageRepository;
        private readonly WebApiSettings _settings;
        private PolarisFamilyDbContext _context;
        public VideosController(IVideoRepository videoRepository,IImageRepository imageRepository,
             IOptions<WebApiSettings> settings,PolarisFamilyDbContext Context)
        {
            _context = Context;
            _videoRepository = videoRepository;
            _imageRepository = imageRepository;
            _settings = settings.Value;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string keyword, [FromQuery] int page, [FromQuery] int pagesize)
        {
            if (0 == pagesize)
                return ResponseHelper.BadRequest();

            IEnumerable<Video> videos = await _videoRepository.GetVideosAsync(keyword, pagesize, page);

            foreach (Video v in videos)
                v.VideoRelativeUrl=  v.VideoRelativeUrl;
            JsonResult result = new JsonResult(videos);
            return result;
        }
        [HttpGet("{videoID}")]
        public async Task<ActionResult> Get([FromRoute] int videoID)
        {
            if (string.IsNullOrEmpty( videoID.ToString()))
                return ResponseHelper.BadRequest();
            Video video = await _videoRepository.GetAsync(videoID);
            video.VideoRelativeUrl= _settings.HostName + video.VideoRelativeUrl;
            JsonResult result = new JsonResult(video);
            return result;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Video value)
        {
            if (null == value || string.IsNullOrEmpty( value.VideoID.ToString()))
                return ResponseHelper.BadRequest();

            // 先查看当前保存的数据中是否有这么一个产品信息
            var video = await _videoRepository.GetAsync(value.VideoID);
            if (null == video)
                await _videoRepository.AddAsync(value);
            else
            {
                video.VideoRelativeUrl = value.VideoRelativeUrl;
                video.VideoName = value.VideoName;
                video.Description = value.Description;
                await _videoRepository.UpdateAsync(video);
            }

            return Ok();
        }
        // PUT api/values/5
        [HttpPut("{videoID}")]
        public async Task<IActionResult> Put([FromRoute] int videoID, [FromBody] Video value)
        {
            if (null == value || string.IsNullOrEmpty( value.VideoID.ToString()))
                return ResponseHelper.BadRequest();

            // 先查看当前保存的数据中是否有这么一个产品信息
            var video = await _videoRepository.GetAsync(value.VideoID);
            if (null == video)
                await _videoRepository.AddAsync(value);
            else
            {
                
                video.VideoRelativeUrl = value.VideoRelativeUrl;
                video.VideoName= value.VideoName;
                video.Description = value.Description;
                
                await _videoRepository.UpdateAsync(video);
            }
            return Ok();
        }
        // DELETE api/values/5
        [HttpDelete("{videoID}")]
        public async Task<IActionResult> Delete(int videoID)
        {
            if (string.IsNullOrEmpty( videoID.ToString()))
                return ResponseHelper.BadRequest();
            await _videoRepository.DeleteAsync(videoID);
            return Ok();
        }


        [HttpGet, Route("getall")]
        public IList<Video> GetAll()
        {
            var lst = _context.Videos.Take(10).ToList();
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
