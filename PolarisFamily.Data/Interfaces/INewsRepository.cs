using PolarisFamily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Data.Interfaces
{
    public interface INewsRepository
    {
        Task<int> AddAsync(News News);
        Task DeleteAsync(int NewsID);
        Task<News> GetAsync(int NewsID);
        Task<List<News>> GetAllAsync();
        Task<int> GetCountAsync();
        Task UpdateAsync(News News);
        Task<List<News>> GetNewsByThemsAsync(int themsID);
        Task<int> AddNewsRevolutionAsync(NewsRevolution newsRevolution);

    }
}
