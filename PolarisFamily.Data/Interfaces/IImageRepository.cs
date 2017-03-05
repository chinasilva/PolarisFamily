using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolarisFamily.Models;

namespace PolarisFamily.Data.Interfaces
{
    public interface IImageRepository
    {
        Task<int> AddAsync(Image image);
        Task<int> DeleteAsync(int imageID);
        Task UpdateAsync(Image image);
        Task<Image> GetAsync(int imageID);
        Task<List<Image>> GetProductImages(int productID);
       // Task<List<Image>> GetNewsImages(int newID);
        Task<List<Image>> GetAllAsync();
        Task<List<Image>> GetSliderAsync();
        Task<IEnumerable<Image>> GetImageAsync(string filter, int pageSize, int pageCount);

    }
}
