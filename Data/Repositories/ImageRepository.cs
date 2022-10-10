using Core.Abstruct.Repositories;
using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ImageRepository : Repository<Image, int>, IImageRepository
    {
        public ImageRepository(DataContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Image>> GetAllAlbumsAsync()
        {
            return await _dbSet
                .Select(a => new Image()
                {
                    Album = a.Album
                }).Distinct()
                .ToListAsync();
        }
        public async Task<IEnumerable<Image>> GetAllImgSelectedAlbumAsync(string album)
        {
            return await _dbSet
                .Where(a => a.Album == album)
                .Select(a => new Image()
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    BottomText = a.BottomText
                }).ToListAsync();
        }
    }
}
