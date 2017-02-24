﻿using System;
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
    public class NewsController : Controller
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IImageRepository _imageRepository;
        private readonly INewsRepository _newsRepository;
        private readonly WebApiSettings _settings;
        private PolarisFamilyDbContext _dbContext = null;

        public NewsController(IVideoRepository videoRepository,INewsRepository newsRepository, IImageRepository imageRepository,
             IOptions<WebApiSettings> settings,PolarisFamilyDbContext Context)
        {
            _dbContext = Context;
            _videoRepository = videoRepository;
            _imageRepository = imageRepository;
            _newsRepository = newsRepository;
            _settings = settings.Value;
        }

        //[HttpGet("newsID")]
        // public async Task<IActionResult> Get(int newsID)
        //{
        //    News news= await _newsRepository.GetAsync(newsID);
        //    news.Images = await _imageRepository.GetNewsImages(newsID);
        //    news.Videos= await _videoRepository.GetVideosNewAsync(newsID);
        //    JsonResult result = new JsonResult(news);
        //    return result;
        //}
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] News value)
        {
            if (null == value || string.IsNullOrEmpty(value.NewsID.ToString()))
                return ResponseHelper.BadRequest();

            // 先查看当前保存的数据中是否有这么一个产品信息
            var news = await _newsRepository.GetAsync(value.NewsID);
            if (null == news)
                await _newsRepository.AddAsync(value);
            else
            {
                news.NewsName= value.NewsName;
                news.NewsDescription = value.NewsDescription;
                await _newsRepository.UpdateAsync(news);
            }
            return Ok();
        }


    }
}