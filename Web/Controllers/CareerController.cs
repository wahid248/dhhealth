using Core.Abstruct.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class CareerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmailService emailService;

        public CareerController(IUnitOfWork unitOfWork, EmailService emailService)
        {
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
        }

        public async Task<IEnumerable<JobPostViewModel>> GetAllJobPosts()
        {
            return (await unitOfWork.JobPostRepository.GetAllJobPosts()).Where(jp => jp.IsActive == true).Select(jp => new JobPostViewModel()
            {
                Id = jp.Id,
                Postion = jp.Postion,
                JobCode = jp.JobCode,
                JobLocation = jp.JobLocation,
                DeadLine = jp.DeadLine
            }).ToList();
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new SectionListViewModel()
            {
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(7),
                JobPosts = await GetAllJobPosts(),
                JobApplicantViewModel = new JobApplicantViewModel(),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(7)
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;

            return View(model);
        }

        [NonAction]
        public async Task<SectionListViewModel> PrepareModel(int Id)
        {

            var jobPostDetails = await unitOfWork.JobPostRepository.GetJobPostDetails(Id);

            jobPostDetails.JobDescriptionArr = Regex.Split(jobPostDetails.JobDescription, @"[\d]+\. ");
            jobPostDetails.JobSpecificationArr = Regex.Split(jobPostDetails.JobSpecification, @"[\d]+\. ");

            var model = new SectionListViewModel()
            {
                JobPostDetails = jobPostDetails,
                JobApplicantViewModel = new JobApplicantViewModel(),
                BannerDetails = await unitOfWork.PageRepository.GetBannerDetails(7),
                PagesWithSections = unitOfWork.SectionRepository.GetPageWithAllSectionList(7)
            };
            ViewBag.BackgroundImageName = model.BannerDetails.ImageUrl;
            return model;
        }

        public async Task<IActionResult> JobPost(int Id, string successMessage = null, string errorMessage = null)
        {
            //ViewBag.BackgroundImageName = "/images/career-cover.png";
            //ViewBag.Heading = "Introducing DH";
            //ViewBag.HeaderText = "While using technology and creativity to make quality healthcare services and health financing accessible for everyone, DH offers a unique opportunity to make an impact in your career while shaping the future of healthcare.";

            var model = await this.PrepareModel(Id);
            model.SuccessMessage = successMessage;
            model.ErrorMessage = errorMessage;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> JobPost(SectionListViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var confirmationTemplate = await unitOfWork.EmailTemplateRepository.GetTemplate((int)Core.Enums.EmailTemplate.EmailTemplates.JobApplyConfirmation);
                var CvSendTemplate = await unitOfWork.EmailTemplateRepository.GetTemplate((int)Core.Enums.EmailTemplate.EmailTemplates.AppliedJobToAdmin);

                var sendCvtoAdminmodel = new EmailViewModel()
                {
                    To = "hr@dh.health",
                    Form = "career@dh.health",
                    Subject = "Application For " + model.JobPostDetails.Postion.Trim(),
                    Name = model.JobApplicantViewModel.Name,
                    PhoneNo = model.JobApplicantViewModel.PhoneNo,
                    Email = model.JobApplicantViewModel.Email,
                    Attachment = model.JobApplicantViewModel.Attachment,
                    EmailTemplateName = CvSendTemplate.TemplateName,
                    Message = CvSendTemplate.Body.Replace($"<b id=\"applicantName\"></b>", $"<b id=\"applicantName\">Applicant Name: {model.JobApplicantViewModel.Name} </b>").Replace($"<p id=\"applicantContact\"></p>", $"<p id=\"applicantContact\">Contact No: {model.JobApplicantViewModel.PhoneNo} </p>").Replace($"<p id=\"applicantEmail\"></p>", $"<p id=\"applicantEmail\">Email: {model.JobApplicantViewModel.Email} </p>")
                };
                var replyToUsermodel = new EmailViewModel()
                {
                    To = model.JobApplicantViewModel.Email,
                    Form = "career@dh.health",
                    Subject = $"Your application for {model.JobPostDetails.Postion.Trim()} has been received",
                    Name = model.JobApplicantViewModel.Name,
                    EmailTemplateName = confirmationTemplate.TemplateName,
                    Message = confirmationTemplate.Body.Replace($"<b id=\"userName\"></b>", $"<b id=\"userName\">Dear {model.JobApplicantViewModel.Name},</b>")
                };

                await emailService.SendEmail(sendCvtoAdminmodel);
                Thread.Sleep(1000);
                await emailService.SendEmail(replyToUsermodel);

                return await JobPost(model.JobPostDetails.JobCode, successMessage: "Application successfully received");
            }
            catch (Exception)
            {
                return await JobPost(model.JobPostDetails.JobCode, errorMessage: "Could not submit the application. Please try again or contact admin");
            }
        }
    }
}