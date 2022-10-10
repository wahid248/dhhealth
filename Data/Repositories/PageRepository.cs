using Core.Abstruct.Repositories;
using Core.Dtos;
using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PageRepository : Repository<Page, int>, IPageRepository
    {
        public PageRepository(DataContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<PageBannerDto>> GetAllBannerDetails()
        {
            return await _dbSet
                .Select(p => new PageBannerDto()
                {
                    PageId = p.Id,
                    PageName = p.Name,
                    ImageId = p.Banner.Id,
                    ImageUrl = p.Banner.ImageUrl
                }).ToListAsync();
        }

        public async Task<IEnumerable<Page>> GetAllPages()
        {
            return await _dbSet
                .Select(p => new Page()
                { 
                    Id = p.Id,
                    Name = p.Name,
                    ControllerName = p.ControllerName,
                    ActionName = p.ActionName,
                    IsEnabled = p.IsEnabled
                }).ToListAsync();
        }

        public async Task<PageBannerDto> GetBannerDetails(int id)
        {
            return await _dbSet
                .Where(p => p.Id == id)
                .Select(p => new PageBannerDto()
                {
                    PageId = p.Id,
                    PageName = p.Name,
                    ImageId = p.Banner.Id,
                    ImageUrl = p.Banner.ImageUrl
                }).FirstOrDefaultAsync();
        }
    }
}
