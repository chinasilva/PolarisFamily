using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.Models;
using PolarisFamily.Web.Models.Images;
using PolarisFamily.Web.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Web.Controllers
{
    public class ImagesController: Controller
    {
        #region --- Private members ---
        private readonly IImageRepository _imageReposity;
        #endregion
        public ImagesController(IImageRepository imageReposity)
        {
            _imageReposity = imageReposity;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            string sessionID = HttpContext.Session.Id;
            List<Image> imageList = null;
                imageList = await _imageReposity.GetAllAsync();
            return View(imageList);
        }

        public IActionResult Error()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            Image i = new Image();
            i = null;
            return View(i);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageName,Description,RelativeUrl")] Image images)
        {
            if (ModelState.IsValid)
            {
                images.RecordUser = HttpContext.User.Identity.Name;
                images.RecordTime = DateTime.Now;
                if (string.IsNullOrEmpty(Request.Form["RelativeUrl"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "图片地址不能为空.");
                    return View(images);
                }
                int count = await _imageReposity.AddAsync(images);
                if (count <= 0)
                {
                    ModelState.AddModelError(string.Empty, "上传失败");
                    ViewBag.Count = 0;
                    return View(images);
                }
                else
                {
                    ViewBag.Count = 1;
                    return RedirectToAction("Index");
                }
            }
            return View(images);
        }

        [Authorize]
        // GET: ShipAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _imageReposity.GetAsync((int)id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }
        [Authorize]
        // POST: ShipAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _imageReposity.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            Image i = new Image();
            if (id == null)
            {
                return NotFound();
            }
            i= await _imageReposity.GetAsync((int)id);
            if (i == null)
            {
                return NotFound();
            }
            return View(i);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,[Bind("ImageID,ImageName,Description,RelativeUrl")] Image Image)
        {
            if (ModelState.IsValid)
            {
                if (id != Image.ImageID)
                {
                    return NotFound();
                }
                //int imageID = 0;
                //string temp = string.Empty;
                //temp = Request.Form["dpImage"].ToString();
                //int.TryParse(temp, out imageID);
                //Image = await _imageReposity.GetAsync(imageID);
                //Image.ImageName = Request.Form["ImageName"].ToString();
                //Image.Description = Request.Form["Description"].ToString();
                if (string.IsNullOrEmpty(Request.Form["RelativeUrl"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "图片地址不能为空.");
                    return View(Image);
                }
                Image.UpdateUser = HttpContext.User.Identity.Name;
                Image.UpdateTime = DateTime.Now;
                await _imageReposity.UpdateAsync(Image);
                return RedirectToAction("Index");
            }
            return View(Image);

        }

        [Authorize]
        // GET: Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _imageReposity.GetAsync((int)id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

    }
}
