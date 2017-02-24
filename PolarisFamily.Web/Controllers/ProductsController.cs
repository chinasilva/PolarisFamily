using Microsoft.AspNetCore.Mvc;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.Models;
using System;
using System.Threading.Tasks;

namespace PolarisFamily.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IImageRepository _imageRepo;
        private readonly IProductRepository _productRepo;

        public ProductsController(IProductRepository productRepo, IImageRepository imageRepo)
        {
            _productRepo = productRepo;
            _imageRepo = imageRepo;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _productRepo.GetAllAsync());
        }

        // GET: Products/Details/5
        [Route(template: "Product/{id}", Name = "ProductDetails")]
        public async Task<IActionResult> Details(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return NotFound();
            }

            Product product = await _productRepo.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var imageLst = await _imageRepo.GetProductImages(id);
            foreach (var image in imageLst)
            {
                //product=image
            }
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepo.AddAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return NotFound();
            }

            Product product = await _productRepo.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepo.UpdateAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return NotFound();
            }

            Product product = await _productRepo.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}