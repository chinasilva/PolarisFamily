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
    public class ThemesController: Controller
    {
        #region --- Private members ---
        private readonly IThemeRepository _ithemeRepository;
        private readonly int _maxProductCount = 50;
        #endregion
        public ThemesController(IThemeRepository ithemeRepository)
        {
            _ithemeRepository = ithemeRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            string sessionID = HttpContext.Session.Id;
            var themeList = await _ithemeRepository.GetAllAsync();
            return View(themeList);
        }


        public IActionResult Error()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            Theme t = new Theme();
            t = null;
            return View(t);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThemeName,Description,RelativeUrl")]Theme themes)
        {
            if (ModelState.IsValid)
            {
                themes.RecordUser = HttpContext.User.Identity.Name;
                themes.RecordTime = DateTime.Now;
                if (string.IsNullOrEmpty(Request.Form["ThemeName"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "栏目名称不能为空.");
                    return View(themes);
                }
                int count = await _ithemeRepository.AddAsync(themes);
                if (count <= 0)
                {
                    ModelState.AddModelError(string.Empty, "上传失败");
                    ViewBag.Count = 0;
                    return View(themes);
                }
                else
                {
                    ViewBag.Count = 1;
                    return RedirectToAction("Index");
                }
                    
            }
            return View(themes);
        }

        [Authorize]
        // GET: ShipAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var v = await _ithemeRepository.GetAsync((int)id);
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
            await _ithemeRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            Theme t = new Theme();
            if (id == null)
            {
                return NotFound();
            }
            t = await _ithemeRepository.GetAsync((int)id);
            if (t == null)
            {
                return NotFound();
            }
            return View(t);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Theme t)
        {
            if (ModelState.IsValid)
            {
                if (id != t.ThemeID)
                {
                    return NotFound();
                }
               
                if (string.IsNullOrEmpty(Request.Form["ThemeName"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "栏目名称不能为空.");
                    return View(t);
                }
                var themeUrl= Request.Form["RelativeUrl"].ToString();
                var themeDesc= Request.Form["Description"].ToString();
                if (!string.IsNullOrEmpty(themeUrl))
                {
                    t.RelativeUrl = themeUrl;
                }
                if (!string.IsNullOrEmpty(themeDesc))
                {
                    t.Description = themeDesc;
                }
                t.UpdateUser = HttpContext.User.Identity.Name;
                t.UpdateTime = DateTime.Now;
                await _ithemeRepository.UpdateAsync(t);
                return RedirectToAction("Index");
            }
            return View(t);

        }

        [Authorize]
        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var v = await _ithemeRepository.GetAsync((int)id);
            if (v == null)
            {
                return NotFound();
            }

            return View(v);
        }



    }
}
