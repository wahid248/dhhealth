using Core.Abstruct.Base;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstruct.Repositories
{
    public interface IImageRepository :IRepository<Image,int>
    {
        Task<IEnumerable<Image>> GetAllAlbumsAsync();
        Task<IEnumerable<Image>> GetAllImgSelectedAlbumAsync(string album);
    }
}
