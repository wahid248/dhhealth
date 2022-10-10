using Core.Abstruct.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class WhoWeAreController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public WhoWeAreController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var model = new SectionListViewModel()
            {
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(2),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(2)
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;

            return View("Index", model);
        }
    }
}