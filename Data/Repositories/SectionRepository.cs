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
    public class SectionRepository : Repository<Section, int>, ISectionRepository
    {
        public SectionRepository(DataContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<SectionDto>> GetSectionListAsync(int pageId)
        {
            return await _dbContext.Set<Page>()
                .Where(p => p.Id == pageId)
                .Include(t => t.PageSections)
                .ThenInclude(t => t.Section)
                .Select(p => p.PageSections.Where(ps => ps.Section.ParentSectionId == null).Select(ps => new SectionDto()
                {
                    Id = ps.Section.Id,
                    TitleLarge = ps.Section.TitleLarge

                })).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<PageWithSectionsDto>> GetPageWithSectionsAsync(int pageNo, int rows)
        {
            return await _dbContext.Set<Page>()
                   .Include(t => t.PageSections)
                   .ThenInclude(t => t.Section)
                   .Select(p => new PageWithSectionsDto()
                   {
                       Page = p.PageSections.Select(ps => new PageDto()
                       {
                           Id = ps.Page.Id,
                           Name = ps.Page.Name
                       }).FirstOrDefault(),
                       Sections = p.PageSections.Select(ps => new SectionDto()
                       {
                           Id = ps.Section.Id,
                           TitleLarge = ps.Section.TitleLarge,
                           //}).Skip((pageNo - 1) * rows).Take(rows).ToList()
                       }).ToList()
                   }).ToListAsync();
        }

        public async Task<PageWithSectionDto> GetPageSectionDetails(int sectionId)
        {
            return await _dbSet.Where(s => s.Id == sectionId)
                .Include(t => t.Image)
                .Include(t => t.PageSections)
                .ThenInclude(t => t.Page)
                .Select(s => new PageWithSectionDto()
                {
                    Section = new SectionDto() { 
                        Id = s.Id,
                        SectionOrder = s.SectionOrder,
                        TitleSmall = s.TitleSmall,
                        TitleLarge = s.TitleLarge,
                        TitleLargeOnTop = s.TitleLargeOnTop,
                        Content = s.Content,
                        CustomCss = s.CustomCss,
                        ImageId = s.ImageId,
                        ParentSectionId = s.ParentSectionId,
                        SectionTypeId = s.SectionTypeId,
                        Image = s.Image == null ? null : new ImageDto()
                        {
                            Id = s.Image.Id,
                            ImageUrl = s.Image.ImageUrl,
                            BottomText = s.Image.BottomText
                        }
                    },
                    Page = s.PageSections.Select(ps =>new PageDto() 
                    { 
                        Id = ps.Page.Id,
                        Name = ps.Page.Name
                    }).FirstOrDefault()
                }).FirstOrDefaultAsync();
        }

        public IEnumerable<PageWithSectionsDto> GetPageWithAllSectionList(int pageId)
        {
            return  _dbContext.Set<Page>()
                    .Where(p => p.Id == pageId)
                    .Include(t => t.PageSections)
                    .ThenInclude(t => t.Section)
                    .ThenInclude(t =>t.Image)
                    .Select(p => new PageWithSectionsDto()
                    {
                       Page = p.PageSections.Select(ps => new PageDto()
                       {
                           Id = ps.Page.Id,
                           Name = ps.Page.Name
                       }).FirstOrDefault(),
                       Sections = p.PageSections.Where(ps => ps.Section.ParentSectionId != null).Select(ps => new SectionDto()
                       {
                           Id = ps.Section.Id,
                           SectionOrder = ps.Section.SectionOrder,
                           TitleSmall = ps.Section.TitleSmall,
                           TitleLarge = ps.Section.TitleLarge,
                           TitleLargeOnTop = ps.Section.TitleLargeOnTop,
                           Image = ps.Section.Image == null ? null : new ImageDto()
                           {
                               Id = ps.Section.Image.Id,
                               ImageUrl = ps.Section.Image.ImageUrl,
                               BottomText = ps.Section.Image.BottomText
                           },
                           Content = ps.Section.Content,
                           ParentSectionId = ps.Section.ParentSectionId,
                           CustomCss = ps.Section.CustomCss
                           
                       }).OrderBy(p => p.SectionOrder).ToList(),
                       ParentSections = p.PageSections.Where(ps => ps.Section.ParentSectionId == null).Select(ps => new SectionDto()
                       {
                           Id = ps.Section.Id,
                           SectionTypeId = ps.Section.SectionTypeId,
                           SectionOrder = ps.Section.SectionOrder,
                           TitleSmall = ps.Section.TitleSmall,
                           TitleLarge = ps.Section.TitleLarge,
                           TitleLargeOnTop = ps.Section.TitleLargeOnTop,
                           Image = ps.Section.Image == null ? null : new ImageDto()
                           {
                               Id = ps.Section.Image.Id,
                               ImageUrl = ps.Section.Image.ImageUrl,
                               BottomText = ps.Section.Image.BottomText
                           },
                           Content = ps.Section.Content
                       }).OrderBy(p => p.SectionOrder).ToList()
                    }).AsEnumerable();
        }

        public async Task<int> GetLowestEligibleSectionOrder(int pageId, int? parentSectionId)
        {
            var sections = await _dbContext.Set<PageSections>()
                .Include(t => t.Section)
                .Where(ps => ps.PageId == pageId)
                .Select(ps => ps.Section)
                .ToListAsync();

            if (parentSectionId == null)
            {
                var parentSections = sections.Where(s => s.ParentSectionId == null).ToList();
                var parentSectionOrders = parentSections.Select(ps => Convert.ToInt32(ps.SectionOrder)).ToList();
                parentSectionOrders.Sort();
                return parentSectionOrders.LastOrDefault() + 1;
            }
            else
            {
                if (parentSectionId <= 0)
                    throw new ArgumentException("No Parent Section Id provided", nameof(parentSectionId));

                var childSections = sections.Where(s => s.ParentSectionId == parentSectionId).ToList();
                var childSectionnOrders = childSections.Select(cs => Convert.ToInt32(cs.SectionOrder)).ToList();
                childSectionnOrders.Sort();
                return childSectionnOrders.LastOrDefault() + 1;
            }
        }
    }
}
