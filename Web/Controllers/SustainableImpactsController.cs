using Core.Abstruct.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class SustainableImpactsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public SustainableImpactsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult>  Index()
        {
            var model = new SectionListViewModel()
            {
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(4),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(4)
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;

            return View(model);
        }
    }
}