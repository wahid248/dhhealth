using Core.Abstruct.Base;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class OurServicesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OurServicesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var model = new SectionListViewModel()
            {
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(3),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(3)
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;

            return View("Index", model);
        }
    }
}