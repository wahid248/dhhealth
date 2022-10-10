using Core.Abstruct.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> IndexAsync()
        {

            var model = new SectionListViewModel()
            {
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(1),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(1)
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;

            return View("Index", model);
        }
    }
}
