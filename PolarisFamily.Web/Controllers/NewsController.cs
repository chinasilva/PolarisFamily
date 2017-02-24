using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class NewsController: Controller
    {
        #region --- Private members ---
        private readonly INewsRepository _newsReposity;
        private readonly IThemeRepository _themeResposity;
        List<Theme> themeList = null;
        #endregion
        public  NewsController(INewsRepository newsReposity,IThemeRepository themeResposity)
        {
            _themeResposity = themeResposity;
            _newsReposity = newsReposity;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            string sessionID = HttpContext.Session.Id;
            List<News> newsList = null;
            newsList = await _newsReposity.GetAllAsync();
            Theme theme = new Theme();
            foreach (var news in newsList)
            {
                theme.ThemeName= await _themeResposity.GetThemeNameByThemsAsync(news.ThemeID);
                news.Themes.ThemeName = theme.ThemeName;
            }
            return View(newsList);
        }

        public IActionResult Error()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            themeList = await _themeResposity.GetAllAsync();
            if (themeList== null)
            {
                ViewData["ThemeID"] = null;
                return View();
            }
            ViewData["ThemeID"] = new SelectList(themeList, "ThemeID", "ThemeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsViewModel nv)
        {
            NewsRevolution newsRevolution = new NewsRevolution();
            if (ModelState.IsValid)
            {
               // string themeID =new SelectList(themeList, "ThemeID", "ThemeName", ViewData["ThemeID"]).SelectedValue.ToString();
                nv.News.RecordUser = HttpContext.User.Identity.Name;
                nv.News.RecordTime = DateTime.Now;
                if (string.IsNullOrEmpty(Request.Form["RelativeUrl"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "新闻链接不能为空.");
                    return View(nv);
                }
                if (string.IsNullOrEmpty(Request.Form["NewsType"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "新闻类型不能为空.");
                    return View(nv);
                }
                var theme = Request.Form["NewsType"].ToString();
                nv.News.NewsDescription = HttpContext.Request.Form["NewsDescription"].ToString();
                nv.News.NewsName = HttpContext.Request.Form["NewsName"].ToString();
                nv.News.ThemeID = int.Parse(theme);
                nv.News.RelativeUrl = HttpContext.Request.Form["RelativeUrl"].ToString();
                var newsID= await _newsReposity.AddAsync(nv.News);
                newsRevolution.newsID = newsID;
                newsRevolution.themeID = int.Parse(theme);
                // Convert.ToInt32(Request.Form["NewsType"].ToString());
                await _newsReposity.AddNewsRevolutionAsync(newsRevolution);

                ViewBag.Count = 1;
                return RedirectToAction("Index");
            }

            return View(nv);
        }


        [Authorize]
        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _newsReposity.GetAsync((int)id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }
        [Authorize]
        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _newsReposity.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            News n = new News();
            if (id == null)
            {
                return NotFound();
            }
            n= await _newsReposity.GetAsync((int)id);
            if (n == null)
            {
                return NotFound();
            }
            themeList = await _themeResposity.GetAllAsync();
            if (themeList == null)
            {
                ViewData["ThemeID"] = null;
                return View();
            }
            ViewData["ThemeID"] = new SelectList(themeList, "ThemeID", "ThemeName");
            return View(n);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, NewsViewModel nv)
        {
            if (ModelState.IsValid)
            {
                //if (id != nv.News.NewsID)
                //{
                //    return NotFound("");
                //}
                if (string.IsNullOrEmpty(Request.Form["RelativeUrl"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "新闻链接不能为空.");
                    return View(nv);
                }
                if (string.IsNullOrEmpty(Request.Form["NewsType"].ToString()))
                {
                    ModelState.AddModelError(string.Empty, "新闻类型不能为空.");
                    return View(nv);
                }
                var theme = Request.Form["NewsType"].ToString();
                nv.News.NewsDescription = HttpContext.Request.Form["NewsDescription"].ToString();
                nv.News.NewsName = HttpContext.Request.Form["NewsName"].ToString();
                nv.News.RelativeUrl= HttpContext.Request.Form["RelativeUrl"].ToString();
                nv.News.ThemeID = int.Parse(theme);
                nv.News.UpdateUser = HttpContext.User.Identity.Name;
                nv.News.UpdateTime = DateTime.Now;
                nv.News.NewsID =Convert.ToInt32( id);
                await _newsReposity.UpdateAsync(nv.News);
                return RedirectToAction("Index");
            }
            return View(nv);

        }

        [Authorize]
        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _newsReposity.GetAsync((int)id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

    }
}
