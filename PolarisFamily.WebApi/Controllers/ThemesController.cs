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
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PolarisFamily.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class ThemesController : Controller
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IImageRepository _imageRepository;
        private readonly INewsRepository _newsRepository;
        private readonly IThemeRepository _themeRepository;

        private readonly WebApiSettings _settings;
        private PolarisFamilyDbContext _dbContext = null;

        public ThemesController(IThemeRepository themeRespository, IVideoRepository videoRepository,INewsRepository newsRepository, IImageRepository imageRepository,
             IOptions<WebApiSettings> settings,PolarisFamilyDbContext Context)
        {
            _dbContext = Context;
            _videoRepository = videoRepository;
            _imageRepository = imageRepository;
            _newsRepository = newsRepository;
            _themeRepository = themeRespository;
            _settings = settings.Value;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string keyword, [FromQuery] int page, [FromQuery] int pagesize)
        {
            if (0 == pagesize)
                return ResponseHelper.BadRequest();

            IEnumerable<Theme> news = await _themeRepository.GetThemesAsync(keyword, pagesize, page);
            JsonResult result = new JsonResult(news);
            return result;
        }

        [HttpGet,Route("themeID")]
        public async Task<IActionResult> Get(int themeID)
        {
            Theme theme= await _themeRepository.GetAsync(themeID);
            JsonResult result = new JsonResult(theme);
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Theme value)
        {
            if (null == value || string.IsNullOrEmpty(value.ThemeID.ToString()))
                return ResponseHelper.BadRequest();

            // 先查看当前保存的数据中是否有这么一个产品信息
            var theme = await _themeRepository.GetAsync(value.ThemeID);
            if (null == theme)
                await _themeRepository.AddAsync(value);
            else
            {
                theme.ThemeName= value.ThemeName;
                theme.Description= value.Description;
                await _themeRepository.UpdateAsync(theme);
            }
            return Ok();
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var lst = await _themeRepository.GetAllAsync();;
            JsonResult result = new JsonResult(lst);
            return result;
        }

    }
}
