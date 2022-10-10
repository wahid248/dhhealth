using Core.Abstruct.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class PartnerWithUsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public PartnerWithUsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.BackgroundImageName = "front-covor.png";
            ViewBag.Heading = "Corporate Healthcare Solutions Tailored According to Your Needs";
            /*ViewBag.HeaderText = "Healthcare Solutions tailored according to your needs";*/
            var model = new SectionListViewModel()
            {
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(5),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(5)
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;

            return View("Index", model);
        }
    }

}