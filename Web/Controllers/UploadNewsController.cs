using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstruct.Base;
using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class UploadNewsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public UploadNewsController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var albums = await unitOfWork.ImageRepository.GetAllAlbumsAsync();

            var model = new SectionListViewModel()
            {
                Albums = albums.Select(a => new ImageViewModel()
                {
                    Id = a.Id,
                    Album = a.Album
                }).ToList(),
                AllNews = await unitOfWork.NewsRepository.GetAllNewsDetails()
            };
            model.SuccessMessage = TempData["SuccessMessage"] as string;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNews(SectionListViewModel model)
        {
            var news = new News()
            {
                Title = model.News.Title,
                LargeImageUrl = model.News.LargeImageUrl,
                MediumImagUrl = model.News.MediumImageUrl,
                SmallImageUrl = model.News.SmallImageUrl,
                Content = model.News.Content
            };

            await unitOfWork.NewsRepository.AddAsync(news, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "News Published successfully!";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowNewsDetails(int id)
        {
            var albums = await unitOfWork.ImageRepository.GetAllAlbumsAsync();

            var model = new SectionListViewModel()
            {
                Albums = albums.Select(a => new ImageViewModel()
                {
                    Id = a.Id,
                    Album = a.Album
                }).ToList(),
                NewsDetails = await unitOfWork.NewsRepository.GetNewsDetails(id)
            };

            model.SuccessMessage = TempData["SuccessMessage"] as string;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNews(SectionListViewModel model)
        {
            var news = await unitOfWork.NewsRepository.GetAsync(n => n.Id == model.NewsDetails.Id);

            news.Title = model.NewsDetails.Title;
            news.LargeImageUrl = model.NewsDetails.LargeImageUrl;
            news.MediumImagUrl = model.NewsDetails.MediumImagUrl;
            news.SmallImageUrl = model.NewsDetails.SmallImageUrl;
            news.Content = model.NewsDetails.Content;

            unitOfWork.NewsRepository.Update(news, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "News Updated Successfully!";

            return RedirectToAction("ShowNewsDetails", new { @Id = model.NewsDetails.Id });
        }
         public async Task<IActionResult> Delete(long Id)
        {
            if (Id > 0)
            {
                unitOfWork.NewsRepository.Delete(await unitOfWork.NewsRepository.GetAsync(x => x.Id == Id));
                await unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return BadRequest("News ID must be greater than 0");
        }
    }
}