using Core.Abstruct.Repositories;
using Core.Dtos;
using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NewsRepository : Repository<News, int>, INewsRepository
    {
        public NewsRepository(DataContext dataContext) : base(dataContext) { }
		public async Task<IEnumerable<NewsDto>> GetAllNewsDetails()
		{
			return await _dbSet
				.Select(n => new NewsDto()
				{
					Id = n.Id,
					Title = n.Title,
					Content = n.Content,
					LargeImageUrl = n.LargeImageUrl,
					MediumImagUrl = n.MediumImagUrl,
					SmallImageUrl = n.SmallImageUrl
				}).OrderByDescending(n => n.Id).ToListAsync();
		}
		public async Task<NewsDto> GetNewsDetails(int id)
		{
			return await _dbSet
				.Where(n => n.Id == id)
				.Select(n => new NewsDto()
				{
					Id = n.Id,
					Title = n.Title,
					Content = n.Content,
					LargeImageUrl = n.LargeImageUrl,
					MediumImagUrl = n.MediumImagUrl,
					SmallImageUrl = n.SmallImageUrl
				}).FirstOrDefaultAsync();
		}
	}
}
