using Core.Abstruct.Base;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmailService emailService;

        public NewsController(IUnitOfWork unitOfWork, EmailService emailService)
        {
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new SectionListViewModel()
            {
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(8),
                EmailViewModel = new EmailViewModel(),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(8),
                AllNews = await unitOfWork.NewsRepository.GetAllNewsDetails()
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> NewsSubscription(SectionListViewModel model)
        {
            //get email template
            var template = await unitOfWork.EmailTemplateRepository.GetTemplate((int)Core.Enums.EmailTemplate.EmailTemplates.NewsSubscription);

            var customer = new Customer()
            {
                Email = model.EmailViewModel.Email,
                IsSubscribed = true
            };
            //check customer does exists
            var getCustomer = await unitOfWork.CustomerRepository.GetCustomer(model.EmailViewModel.Email);
            if (getCustomer != null && getCustomer.Email == customer.Email)
                return StatusCode(400, "Already Subscribed!");

            await unitOfWork.CustomerRepository.AddAsync(customer);
            await unitOfWork.SaveChangesAsync();
            
            var replyToUsermodel = new EmailViewModel()
            {
                To = model.EmailViewModel.Email,
                Form = "info@dh.health",
                Subject = "Subscription Successfull",
                EmailTemplateName = template.TemplateName,
                Message = template.Body.Replace($"<p id=\"userEmail\"></p>", $"<p id=\"userEmail\">{model.EmailViewModel.Email} This email has been subscribed to our news.</p>")
            };

            try
            {
                await emailService.SendEmail(replyToUsermodel);

                return Ok(new {message = "Subscription Successfull!"});
            }
            catch (Exception)
            {
                return StatusCode(500, "Subscription request not accepted! Please try again later.");
            }
            
        }
    }
}