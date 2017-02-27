using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.Models;
using Microsoft.EntityFrameworkCore;

namespace PolarisFamily.Data.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private PolarisFamilyDbContext  _dbContext = null;
        public ThemeRepository(PolarisFamilyDbContext context)
        {
            _dbContext = context;
        }
        public async Task<int> AddAsync(Theme theme)
        {
            if (null == theme)
                return -1;
            _dbContext.Theme.Add(theme);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int themeID)
        {
            var pi =  _dbContext.Theme.SingleOrDefault(t => t.ThemeID== themeID);
            if (null != pi)
            {
                _dbContext.Theme.Remove(pi);
                return await _dbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<Theme> GetAsync(int themeID)
        {
            return await _dbContext.Theme
                .Where(i => i.ThemeID == themeID).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Theme theme)
        {
            _dbContext.Theme.Update(theme);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Theme>> GetAllAsync()
        {
            return await _dbContext.Theme.ToListAsync();
        }
        public async Task<string> GetThemeNameByThemsAsync(int themeID)
        {
            Theme theme = await _dbContext.Theme.SingleOrDefaultAsync(t => t.ThemeID == themeID);
            if (theme == null)
                return string.Empty;
            else
                return theme.ThemeName;

        }
        public async Task<IEnumerable<Theme>> GetThemesAsync(string filter, int pageSize, int pageCount)
        {
            var results = await _dbContext.Theme.Where
                    (t => (String.IsNullOrEmpty(filter) ||
                     t.ThemeName.Contains(filter) || t.Description.Contains(filter)))
                    .Select(t => new { Theme = t, })
                    .Skip(pageSize * pageCount)
                    .Take(pageSize)
                    .ToListAsync();

            return results.Select(t => t.Theme);
        }
    }
}
