using Core.Abstruct.Base;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmailService emailService;

        public ContactUsController(IUnitOfWork unitOfWork, EmailService emailService)
        {
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new SectionListViewModel()
            {
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(9),
                ContactUsViewModel = new ContactUsViewModel(),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(9)
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SectionListViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var confirmationTemplate = await unitOfWork.EmailTemplateRepository.GetTemplate((int)Core.Enums.EmailTemplate.EmailTemplates.UserConfirmation);
                var adminTemplate = await unitOfWork.EmailTemplateRepository.GetTemplate((int)Core.Enums.EmailTemplate.EmailTemplates.UserQueryToAdmin);

                var sendQuerytoAdminmodel = new EmailViewModel()
                {
                    To = "info@dh.health",
                    Form = "info@dh.health",
                    Subject = "Query from User",
                    Name = model.ContactUsViewModel.Name,
                    Email = model.ContactUsViewModel.Email,
                    PhoneNo = model.ContactUsViewModel.PhoneNo,
                    EmailTemplateName = adminTemplate.TemplateName,
                    Message = adminTemplate.Body.Replace($"<b id=\"UserName\"></b>", $"<b id=\"UserName\">User Name: {model.ContactUsViewModel.Name} </b>").Replace($"<p id=\"Contact\"></p>", $"<p id=\"Contact\">Contact No: {model.ContactUsViewModel.PhoneNo}</p>").Replace($"<p id=\"Email\"></p>", $"<p id=\"Email\">Email: {model.ContactUsViewModel.Email}</p>").Replace($"<p id=\"message\"></p>", $"<p id=\"message\">Message: {model.ContactUsViewModel.Message}</p>")
                };
                var replyToUsermodel = new EmailViewModel()
                {
                    To = model.ContactUsViewModel.Email,
                    Form = "info@dh.health",
                    Subject = "Mail Receive Confirmation",
                    Name = model.ContactUsViewModel.Name,
                    EmailTemplateName = confirmationTemplate.TemplateName,
                    Message = confirmationTemplate.Body.Replace($"<b id=\"userName\"></b>", $"<b id=\"UserName\">Dear {model.ContactUsViewModel.Name},</b>")
                };

                await emailService.SendEmail(sendQuerytoAdminmodel);
                Thread.Sleep(1000);
                await emailService.SendEmail(replyToUsermodel);

                await SaveUserInformation(model.ContactUsViewModel);
                model.SuccessMessage = "Message successfully received";
                model.ErrorMessage = null;

                
                model.PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(9);
                model.BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(9);
                ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;
                return View(model);
            }
            catch (Exception)
            {
                model.SuccessMessage = null;
                model.ErrorMessage = "Could not send the message. Please try again or contact admin";
                model.PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(9);
                model.BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(9);
                ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;
                return View(model);
            }

        }

        [NonAction]
        public async Task SaveUserInformation(ContactUsViewModel model)
        {
            var customer = await unitOfWork.CustomerRepository.GetCustomer(model.Email);

            if (customer != null)
            {
                customer.Name = model.Name;
                customer.PhoneNo = model.PhoneNo;

                unitOfWork.CustomerRepository.Update(customer);
                await unitOfWork.SaveChangesAsync();

                var contact = new ContactUs()
                {
                    CustomerId = customer.Id,
                    Message = model.Message
                };

                await unitOfWork.ContactUsRepository.AddAsync(contact);
                await unitOfWork.SaveChangesAsync();
            }
            else
            {
                var newCustomer = new Customer()
                {
                    Name = model.Name,
                    PhoneNo = model.PhoneNo,
                    Email = model.Email,
                    IsSubscribed = true
                };

                await unitOfWork.CustomerRepository.AddAsync(newCustomer);
                await unitOfWork.SaveChangesAsync();

                var contact = new ContactUs()
                {
                    CustomerId = newCustomer.Id,
                    Message = model.Message
                };

                await unitOfWork.ContactUsRepository.AddAsync(contact);
                await unitOfWork.SaveChangesAsync();
            }
        }
    }
}