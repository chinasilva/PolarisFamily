using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.Models;
using Microsoft.EntityFrameworkCore;

namespace PolarisFamily.Data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private PolarisFamilyDbContext  _dbContext = null;
        public ImageRepository(PolarisFamilyDbContext context)
        {
            _dbContext = context;
        }
        public async Task<int> AddAsync(Image image)
        {
            if (null == image)
                return -1;
            _dbContext.Images.Add(image);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int ImageID)
        {
            var pi = _dbContext.Images.SingleOrDefault(i => i.ImageID == ImageID);
            if (null != pi)
            {
                _dbContext.Images.Remove(pi);
                return await _dbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<Image> GetAsync(int imageID)
        {
            return await _dbContext.Images
                .Where(i => i.ImageID == imageID).SingleOrDefaultAsync();
        }

        public async Task<List<Image>> GetProductImages(int productID)
        {
            var results = await _dbContext.Images.Where
                (i => i.ProductID == productID)
                .Select(i => new { ProductImage = i, })
                .ToListAsync();

            return results.Select(i => i.ProductImage).ToList();
        }

        //public async Task<List<Image>> GetNewsImages(int newID)
        //{
        //    var results = await _dbContext.ImageRevolutions.Where
        //        (i => i.NewsID== newID)
        //        .Select(i => new { ImageRevolution = i, })
        //        .ToListAsync();

        //    return results.Select(i => i.ImageRevolution).ToList();
        //}

        public async Task<IEnumerable<Image>> GetImageAsync(string filter, int pageSize, int pageCount)
        {
            var results = await _dbContext.Images.Where
                    (i => (String.IsNullOrEmpty(filter) ||
                     i.ImageName.Contains(filter) || i.Description.Contains(filter)))
                    .Select(i => new { Image = i, })
                    .Skip(pageSize * pageCount)
                    .Take(pageSize)
                    .ToListAsync();

            return results.Select(i => i.Image);
        }

        public async Task UpdateAsync(Image image)
        {
            _dbContext.Images.Update(image);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Image>> GetAllAsync()
        {
            return await _dbContext.Images.ToListAsync();
        }

        public async Task<List<Image>> GetSliderAsync()
        {
            var results = await _dbContext.Images.Where
                (i => (i.Description.Contains("滚图")))
                .Select(i => new { Image = i, })
                .ToListAsync();
            return results.Select(i=>i.Image).ToList();
        }

    }
}
