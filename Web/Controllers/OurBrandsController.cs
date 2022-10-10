using Core.Abstruct.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class OurBrandsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OurBrandsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var model = new SectionListViewModel()
            {
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(6),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(6)
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;

            return View("Index", model);
        }
    }
}