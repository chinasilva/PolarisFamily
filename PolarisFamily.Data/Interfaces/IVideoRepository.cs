using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolarisFamily.Models;

namespace PolarisFamily.Data.Interfaces
{
    public interface IVideoRepository
    {
        Task<int> AddAsync(Video Video);
        Task DeleteAsync(int VideoID);
        Task<Video> GetAsync(int VideoID);
        Task<List<Video>> GetAllAsync();
        Task<int> GetCountAsync();
        Task UpdateAsync(Video video);
        Task<IEnumerable<Video>> GetVideosAsync(string filter, int pageSize, int pageCount);
        Task<List<Video>> GetVideosNewAsync(int NewsID);

    }
}
