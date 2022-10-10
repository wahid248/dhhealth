using Core.Abstruct.Base;
using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstruct.Repositories
{
    public interface IPageRepository : IRepository<Page, int>
    {
        Task<IEnumerable<Page>> GetAllPages();
        Task<PageBannerDto> GetBannerDetails(int id);
        Task<IEnumerable<PageBannerDto>> GetAllBannerDetails();
    }
}
