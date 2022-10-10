using Core.Abstruct.Base;
using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstruct.Repositories
{
    public interface ISectionRepository : IRepository<Section,int>
    {
        Task<IEnumerable<SectionDto>> GetSectionListAsync(int pageId);
        Task<IEnumerable<PageWithSectionsDto>> GetPageWithSectionsAsync(int pageNo, int rows);
        Task<PageWithSectionDto> GetPageSectionDetails(int sectionId);

        //for frontend
        IEnumerable<PageWithSectionsDto> GetPageWithAllSectionList(int pageId);

        Task<int> GetLowestEligibleSectionOrder(int pageId, int? parentSectionId);
    }
}
