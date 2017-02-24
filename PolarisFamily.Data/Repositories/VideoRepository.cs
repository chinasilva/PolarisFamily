using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.Models;
using Microsoft.EntityFrameworkCore;

namespace PolarisFamily.Data.Repositories
{
    public class VideosRepository : IVideoRepository
    {
        private PolarisFamilyDbContext _dbContext = null;

        public VideosRepository(PolarisFamilyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Video video)
        {
            if (null == video)
                return -1;
            _dbContext.Videos.Add(video);
            await _dbContext.SaveChangesAsync();
            return video.VideoID;
        }

        public async Task DeleteAsync(int videoID)
        {
            var video = await _dbContext.Videos
                .SingleOrDefaultAsync(v => v.VideoID == videoID);

            if (video != null)
            {
                _dbContext.Videos.Remove(video);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Video> GetAsync(int videoID)
        {
            return await _dbContext.Videos.Where(v =>v.VideoID == videoID).SingleOrDefaultAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Videos.CountAsync();
        }
        public async Task<List<Video>> GetAllAsync()
        {
            return await _dbContext.Videos.ToListAsync();
        }
        public async Task<IEnumerable<Video>> GetVideosAsync( string filter, int pageSize, int pageCount)
        {
            var results = await _dbContext.Videos.Where
                    (v => (String.IsNullOrEmpty(filter) ||
                     v.VideoName.Contains(filter) || v.Description.Contains(filter)))
                    .Select(v => new { Video= v, })
                    .Skip(pageSize * pageCount)
                    .Take(pageSize)
                    .ToListAsync();

            return results.Select(v => v.Video);
        }
        public async Task UpdateAsync(Video video)
        {
            if (null == video)
                return;
            _dbContext.Videos.Update(video);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Video>> GetVideosNewAsync(int NewsID)
        {
            var results = await _dbContext.Videos.Where(v => v.NewsID==NewsID)
                   .Select(v => new { Video = v, })
                   .OrderByDescending(v => v.Video.RecordTime)
                   .ToListAsync();
            return results.Select(v => v.Video).ToList();
        }
    }
}
