using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstruct.Base;
using Core.Dtos;
using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.Models;
using Web.ViewModels;
using System;
using Core.Enums.SectionType;

namespace Web.Controllers
{
    [Authorize]
    public class SectionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public SectionController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        [NonAction]
        public async Task<SectionListViewModel> PrepareModel()
        {
            var model = new SectionListViewModel()
            {
                Pages = await GetAllPages(),
                Sections = await GetAllSections(),
                Albums = await GetAllAlbums(),
                PagesWithSections = await GetPagesWithSections(),
                PageList = new List<SelectListItem>(),
                SectionList = new List<SelectListItem>(),
                SectionTypeList = new List<SelectListItem>(),
                RadioButtons = new List<Models.RadioButton>()
            };

            foreach (var p in model.Pages)
            {
                model.PageList.Add(new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                });
            }

            foreach (var s in model.Sections)
            {
                model.SectionList.Add(new SelectListItem()
                {
                    Value = s.Id.ToString(),
                    Text = s.TitleLarge
                });
            }

            foreach (var s in Enum.GetValues(typeof(SectionTypes)))
            {

                model.SectionTypeList.Add(new SelectListItem()
                {
                    Value = (Convert.ToInt32(s))
                    .ToString(),
                    Text = Enum.GetName(typeof(SectionTypes), s)
                });
            }

            model.RadioButtons = model.Pages.Select((p, index) => new RadioButton() { Id = p.Id, Name = p.Name, IsChecked = index == 0 }).ToList();

            return model;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.PrepareModel();
            model.SuccessMessage = TempData["SuccessMessage"] as string;

            if (TempData["SectionListViewModelSerialized"] != null)
            {
                var previousModel = JsonConvert.DeserializeObject<SectionListViewModel>(TempData["SectionListViewModelSerialized"] as string);
                model.Section = previousModel.Section;
                model.RadioButtons = model.Pages.Select(p => new RadioButton() { Id = p.Id, Name = p.Name, IsChecked = p.Id == previousModel.Page.Id }).ToList();
                model.Page = previousModel.Page;
                model.UseParentSection = previousModel.UseParentSection;
                model.PageList.ForEach(pl => pl.Selected = Convert.ToInt32(pl.Value) == previousModel.Page.Id);
                model.Sections = await GetAllSections(previousModel.Page.Id);
                if (model.UseParentSection)
                {
                    model.SectionList = model.Sections.Select(sl => new SelectListItem()
                    {
                        Value = sl.Id.ToString(),
                        Text = sl.TitleLarge,
                        Selected = Convert.ToInt32(sl.Id) == previousModel.ParentSectionId
                    }).ToList();  
                }
                else
                {
                    model.SectionList = model.Sections.Select(sl => new SelectListItem()
                    {
                        Value = sl.Id.ToString(),
                        Text = sl.TitleLarge,
                        Selected = Convert.ToInt32(sl.Id) == model.Sections.First().Id
                    }).ToList();
                }

                model.SectionTypeList.ForEach(stl => stl.Selected = Convert.ToInt32(stl.Value) == previousModel.SectionTypeId);

                ModelState.AddModelError("OrderError", TempData["OrderEligibilityError"] as string);
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSection(SectionListViewModel model)
        {
            var section = new Section()
            {
                SectionTypeId = model.SectionTypeId,
                SectionOrder = model.Section.SectionOrder,
                TitleSmall = model.Section.TitleSmall,
                TitleLarge = model.Section.TitleLarge,
                TitleLargeOnTop = model.Section.TitleLargeOnTop,
                Content = model.Section.Content,
                ImageId = model.Section.ImageId,
                CustomCss = model.Section.CustomCss,
                ParentSectionId = model.UseParentSection ? (int?)model.ParentSectionId : null
            };

            var eligibleSectionOrder = await unitOfWork.SectionRepository.GetLowestEligibleSectionOrder(model.Page.Id, section.ParentSectionId);
            if (eligibleSectionOrder > section.SectionOrder)
            {
                TempData["OrderEligibilityError"] = $"Section order should be {eligibleSectionOrder}";
                TempData["SectionListViewModelSerialized"] = JsonConvert.SerializeObject(model);
                return RedirectToAction("Index");
            }
            
            await unitOfWork.SectionRepository.AddAsync(section, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            var pageSection = new PageSections()
            {
                PageId = model.Page.Id,
                SectionId = section.Id
            };

            await unitOfWork.PageSectionsRepository.AddAsync(pageSection, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Section created successfully!";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowSectionDetails(int sectionId, int pageId)
        {
            var model = new SectionListViewModel()
            {
                Pages = await GetAllPages(),
                Sections = await GetAllSections(pageId),
                Albums = await GetAllAlbums(),
                SectionDetails = await unitOfWork.SectionRepository.GetPageSectionDetails(sectionId),
                SuccessMessage = TempData["SuccessMessage"] as string
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSection(SectionListViewModel model)
        {

            var section = await unitOfWork.SectionRepository.GetAsync(x => x.Id == model.SectionDetails.Section.Id);

            section.SectionTypeId = model.SectionTypeId;
            section.SectionOrder = model.SectionDetails.Section.SectionOrder;
            section.TitleSmall = model.SectionDetails.Section.TitleSmall;
            section.TitleLarge = model.SectionDetails.Section.TitleLarge;
            section.TitleLargeOnTop = model.SectionDetails.Section.TitleLargeOnTop;
            section.Content = model.SectionDetails.Section.Content;
            section.ImageId = model.SectionDetails.Section.ImageId;
            section.CustomCss = model.SectionDetails.Section.CustomCss;
            section.ParentSectionId = model.UseParentSection ? (int?)model.ParentSectionId : null;

            unitOfWork.SectionRepository.Update(section, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            var pageSection = await unitOfWork.PageSectionsRepository.GetAsync(x => x.SectionId == model.SectionDetails.Section.Id);

            pageSection.PageId = model.Page.Id;
            pageSection.SectionId = model.SectionDetails.Section.Id;

            unitOfWork.PageSectionsRepository.Update(pageSection, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Section Details Updated successfully!";

            return RedirectToAction("ShowSectionDetails", new { @sectionId = model.SectionDetails.Section.Id , @pageId = model.Page.Id} );
        }


        public async Task<IActionResult> Delete(long Id)
        {
            if (Id > 0)
            {
                unitOfWork.SectionRepository.DeletePermanantly(await unitOfWork.SectionRepository.GetAsync(x => x.Id == Id));
                unitOfWork.PageSectionsRepository.DeletePermanantly(await unitOfWork.PageSectionsRepository.GetAsync(x => x.Section.Id == Id));
                await unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index", "Section");
            }
            return BadRequest("Section ID must be greater than 0");
        }

        [NonAction]
        public async Task<IEnumerable<PageViewModel>> GetAllPages()
        {
            return (await unitOfWork.PageRepository.GetAllPages()).Select(p => new PageViewModel()
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }

        [NonAction]
        public async Task<IEnumerable<ImageViewModel>> GetAllAlbums()
        {
            return (await unitOfWork.ImageRepository.GetAllAlbumsAsync()).Select(a => new ImageViewModel()
            {
                Id = a.Id,
                Album = a.Album
            }).ToList();
        }

        public async Task<IEnumerable<SectionViewModel>> GetAllSections(int pageId = 1)
        {
            return (await unitOfWork.SectionRepository.GetSectionListAsync(pageId))?.Select(s => new SectionViewModel()
            {
                Id = s.Id,
                TitleLarge = s.TitleLarge
            }).ToList();
        }

        [NonAction]
        public async Task<IEnumerable<PageWithSectionsDto>> GetPagesWithSections(int pageNo = 1, int rows = 5)
        {
            return await unitOfWork.SectionRepository.GetPageWithSectionsAsync(pageNo, rows);
        }
    }
}
