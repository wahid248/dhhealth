using Core.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.ViewModels
{
    public class SectionListViewModel
    {
        public SectionViewModel Section { get; set; }
        public PageViewModel Page { get; set; }
        public ImageViewModel Image { get; set; }
        public NewsViewModel News { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public bool UseParentSection { get; set; }
        public int? ParentSectionId { get; set; }
        public int SectionTypeId { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }
        public IEnumerable<ImageViewModel> Albums { get; set; }
        public PageWithSectionDto SectionDetails { get; set; }
        public IEnumerable<SectionViewModel> Sections { get; set; }
        public IEnumerable<PageWithSectionsDto> PagesWithSections { get; set; }
        public IEnumerable<PageViewModel> Pages { get; set; }
        public IEnumerable<JobPostViewModel> JobPosts { get; set; }
        public IEnumerable<PageBannerDto> Banners { get; set; }
        public PageBannerDto BannerDetails { get; set; }
        public IEnumerable<NewsDto> AllNews { get; set; }
        public NewsDto NewsDetails { get; set; }

        public JobPostViewModel JobPost { get; set; }
        public JobPostDto JobPostDetails { get; set; }
        public ContactUsViewModel ContactUsViewModel { get; set; }

        public EmailViewModel EmailViewModel { get; set; }
        public JobApplicantViewModel JobApplicantViewModel { get; set; }
        public List<SelectListItem> PageList { get; set; }
        public List<SelectListItem> SectionList { get; set; }
        public List<SelectListItem> SectionTypeList { get; set; }
        public List<RadioButton> RadioButtons { get; set; }
    }
}
