using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.Models;
using PolarisFamily.Web.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Web.Controllers
{
    public class VideosController: Controller
    {
        #region --- Private members ---
        private readonly INewsRepository _inewsRepository;
        private readonly IImageRepository _imageReposity;
        private readonly IProductRepository _productRepository;
        private readonly IVideoRepository _videoReposity;
        private readonly int _maxProductCount = 50;
        #endregion
        public VideosController(INewsRepository inewsRepository,IVideoRepository videoReposity,IImageRepository imageReposity
           )
        {
            _imageReposity = imageReposity;
            _videoReposity = videoReposity;
            _inewsRepository = inewsRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            string sessionID = HttpContext.Session.Id;
            var videoList = await _videoReposity.GetAllAsync();
            return View(videoList);
        }


        public IActionResult Error()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            Video v = new Video();
            v = null;
            return View(v);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoName,Description,VideoRelativeUrl")]Video videos)
        {
            if (ModelState.IsValid)
            {
                videos.RecordUser = HttpContext.User.Identity.Name;
                videos.RecordTime = DateTime.Now;
                if (string.IsNullOrEmpty(Request.Form["VideoRelativeUrl"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "视频地址不能为空.");
                    return View(videos);
                }
                int count = await _videoReposity.AddAsync(videos);
                if (count <= 0)
                {
                    ModelState.AddModelError(string.Empty, "上传失败");
                    ViewBag.Count = 0;
                    return View(videos);
                }
                else
                {
                    ViewBag.Count = 1;
                    return RedirectToAction("Index");
                }
                    
            }
            return View(videos);
        }

        [Authorize]
        // GET: ShipAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var v = await _videoReposity.GetAsync((int)id);
            if (v == null)
            {
                return NotFound();
            }

            return View(v);
        }
        [Authorize]
        // POST: ShipAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _videoReposity.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            Video v = new Video();
            if (id == null)
            {
                return NotFound();
            }
            v = await _videoReposity.GetAsync((int)id);
            if (v == null)
            {
                return NotFound();
            }
            return View(v);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("VideoID,VideoName,Description,VideoRelativeUrl")] Video V)
        {
            if (ModelState.IsValid)
            {
                if (id != V.VideoID)
                {
                    return NotFound();
                }
               
                if (string.IsNullOrEmpty(Request.Form["RelativeUrl"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "图片地址不能为空.");
                    return View(V);
                }
                V.UpdateUser = HttpContext.User.Identity.Name;
                V.UpdateTime = DateTime.Now;
                await _videoReposity.UpdateAsync(V);
                return RedirectToAction("Index");
            }
            return View(V);

        }

        [Authorize]
        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var v = await _videoReposity.GetAsync((int)id);
            if (v == null)
            {
                return NotFound();
            }

            return View(v);
        }



    }
}
