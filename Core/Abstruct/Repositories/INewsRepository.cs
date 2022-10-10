using Core.Abstruct.Base;
using Core.Dtos;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstruct.Repositories
{
    public interface INewsRepository : IRepository<News, int>
    {
        //Task<IEnumerable<NewsDto>> GetNewsById (int id);
        Task<NewsDto> GetNewsDetails(int id);
        Task<IEnumerable<NewsDto>> GetAllNewsDetails();
    }
}
