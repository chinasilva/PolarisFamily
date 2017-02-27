using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolarisFamily.Models;

namespace PolarisFamily.Data.Interfaces
{
    public interface IThemeRepository
    {
        Task<int> AddAsync(Theme theme);
        Task<int> DeleteAsync(int themeID);
        Task UpdateAsync(Theme theme);
        Task<Theme> GetAsync(int themeID);
        Task<List<Theme>> GetAllAsync();
        Task<string> GetThemeNameByThemsAsync(int themeID);
        Task<IEnumerable<Theme>> GetThemesAsync(string filter, int pageSize, int pageCount);

    }
}
