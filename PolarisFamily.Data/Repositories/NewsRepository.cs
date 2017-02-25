using Microsoft.EntityFrameworkCore;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private PolarisFamilyDbContext _dbContext = null;

        public NewsRepository(PolarisFamilyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(News news)
        {
            if (null == news)
                return -1;
            _dbContext.News.Add(news);
            await _dbContext.SaveChangesAsync();
            return news.NewsID;
        }
        public async Task<int> AddNewsRevolutionAsync(NewsRevolution newsRevolution)
        {
            if (null == newsRevolution)
                return -1;
            _dbContext.NewsRevolution.Add(newsRevolution);
            await _dbContext.SaveChangesAsync();
            return newsRevolution.newsRevolationID;
        }
        public async Task DeleteAsync(int newsID)
        {
            var news = await _dbContext.News
                .SingleOrDefaultAsync(n => n.NewsID== newsID);

            if (news != null)
            {
                _dbContext.News.Remove(news);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<News> GetAsync(int newsID)
        {
            return await _dbContext.News.Where(n => n.NewsID == newsID).SingleOrDefaultAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.News.CountAsync();
        }
        public async Task<List<News>> GetAllAsync()
        {
            return await _dbContext.News.ToListAsync();
        }
        public async Task UpdateAsync(News news)
        {
            if (null == news)
                return;
            _dbContext.News.Update(news);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<News>> GetNewsByThemsAsync(int themsID)
        {
            var results = await _dbContext.News.Where(n =>n.ThemeID== themsID)
                    .Select(n => new { News = n, })
                    .OrderByDescending(n => n.News.RecordTime)
                    .ToListAsync();
            return results.Select(n => n.News).ToList();
        }
        public async Task<IEnumerable<News>> GetNewsAsync(string filter, int pageSize, int pageCount)
        {
            var results = await _dbContext.News.Where
                    (p => (String.IsNullOrEmpty(filter) ||
                     p.NewsName.Contains(filter) || p.NewsDescription.Contains(filter)))
                    .Select(p => new { News = p, })
                    .Skip(pageSize * pageCount)
                    .Take(pageSize)
                    .ToListAsync();

            return results.Select(p => p.News);
        }

    }
}
