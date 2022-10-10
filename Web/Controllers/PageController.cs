using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstruct.Base;
using Core.Dtos;
using Core.Entities;
using Core.Entities.Identity;
using Data.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class PageController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public PageController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var pages = await unitOfWork.PageRepository.GetAllPages();
            var model = pages.Select(p => new PageViewModel()
            {
                Id =p.Id,
                Name = p.Name,
                Controller = p.ControllerName,
                Action = p.ActionName,
                IsEnabled = p.IsEnabled
            }).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(IEnumerable<PageViewModel> model)
        {
            
            var pages = await unitOfWork.PageRepository.GetAllAsync();
            foreach (var m in model)
            {
                foreach (var p in pages)
                {
                    if (m.Id == p.Id)
                    {
                        p.IsEnabled = m.IsEnabled;
                    }
                }
            }

            unitOfWork.PageRepository.UpdateRange(pages, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            return Ok();
        }

        public async Task<IActionResult> Banner()
        {
            var pages = await unitOfWork.PageRepository.GetAllPages();
            var albums = await unitOfWork.ImageRepository.GetAllAlbumsAsync();

            var model = new SectionListViewModel()
            {
                Pages = pages.Select(p => new PageViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList(),
                Albums = albums.Select(a => new ImageViewModel()
                {
                    Id = a.Id,
                    Album = a.Album
                }).ToList(),
                Banners = await unitOfWork.PageRepository.GetAllBannerDetails(),
                RadioButtons = new List<Models.RadioButton>()
            };
            model.RadioButtons = model.Pages.Select((p, index) => new RadioButton() { Id = p.Id, Name = p.Name, IsChecked = index == 0 }).ToList();
            model.SuccessMessage = TempData["SuccessMessage"] as string;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBanner(SectionListViewModel model)
        {
            var page = await unitOfWork.PageRepository.GetAsync(p => p.Id == model.Page.Id);
            page.Banner = new Image() { Id = model.Image.Id };

            unitOfWork.PageRepository.Update(page, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Banner created successfully!";

            return RedirectToAction("Banner");
        }
        public async Task<IActionResult> ShowBannerDetails(int id)
        {
            var pages = await unitOfWork.PageRepository.GetAllPages();
            var albums = await unitOfWork.ImageRepository.GetAllAlbumsAsync();

            var model = new SectionListViewModel()
            {
                Pages = pages.Select(p => new PageViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList(),
                Albums = albums.Select(a => new ImageViewModel()
                {
                    Id = a.Id,
                    Album = a.Album
                }).ToList(),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(id)
            };
           
            model.SuccessMessage = TempData["SuccessMessage"] as string;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(SectionListViewModel model)
        {
            var page = await unitOfWork.PageRepository.GetAsync(p => p.Id == model.BannerDetails.PageId);
            page.BannerId = model.BannerDetails.ImageId;
            unitOfWork.PageRepository.Update(page);
            await unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Banner Image Updated Successfully!";

            return RedirectToAction("ShowBannerDetails", new { @Id = model.BannerDetails.PageId });
        }
    }
}