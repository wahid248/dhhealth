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
    public class JobController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public JobController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<JobPostViewModel>> GetAllJobPosts()
        {
            return (await unitOfWork.JobPostRepository.GetAllJobPosts()).Select(jp => new JobPostViewModel()
            {
                Id = jp.Id,
                Postion = jp.Postion,
                JobCode = jp.JobCode,
                JobLocation = jp.JobLocation,
                DeadLine = jp.DeadLine,
                IsActive = jp.IsActive
            }).OrderByDescending(jp => jp.JobCode).ToList();
        }
        public async Task<IActionResult> IndexAsync()
        {
            var model = new SectionListViewModel()
            {
                JobPosts = await GetAllJobPosts(),
                SuccessMessage = TempData["SuccessMessage"] as string,
                ErrorMessage = TempData["ErrorMessage"] as string
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SectionListViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var jobPost = new JobPost()
                {
                    Intro = model.JobPost.Intro,
                    Postion = model.JobPost.Postion,
                    JobCode = model.JobPost.JobCode,
                    EmploymentType = model.JobPost.EmploymentType,
                    JobDescription = model.JobPost.JobDescription,
                    JobSpecification = model.JobPost.JobSpecification,
                    ApplyProcess = model.JobPost.ApplyProcess,
                    JobLocation = model.JobPost.JobLocation,
                    DeadLine = model.JobPost.DeadLine
                };

                await unitOfWork.JobPostRepository.AddAsync(jobPost, userManager.GetUserId(User));
                await unitOfWork.SaveChangesAsync();

                TempData["SuccessMessage"] = "Job Post created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Could not create this job. Please try again";

                return View(model);
            }

        }

        public async Task<IActionResult> JobPostDetails(int jobId)
        {
            var model = new SectionListViewModel()
            {
                JobPostDetails = await unitOfWork.JobPostRepository.GetJobPostDetails(jobId),
                SuccessMessage = TempData["SuccessMessage"] as string
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateJobStatus(int Id, bool IsActive)
        {

            var jobDetails = await unitOfWork.JobPostRepository.GetAsync(x => x.Id == Id);

            jobDetails.IsActive = IsActive;

            unitOfWork.JobPostRepository.Update(jobDetails, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Update(SectionListViewModel model)
        {

            var jobDetails = await unitOfWork.JobPostRepository.GetAsync(x => x.Id == model.JobPostDetails.Id);

            jobDetails.Intro = model.JobPostDetails.Intro;
            jobDetails.Postion = model.JobPostDetails.Postion;
            jobDetails.JobCode = model.JobPostDetails.JobCode;
            jobDetails.EmploymentType = model.JobPostDetails.EmploymentType;
            jobDetails.JobDescription = model.JobPostDetails.JobDescription;
            jobDetails.JobSpecification = model.JobPostDetails.JobSpecification;
            jobDetails.ApplyProcess = model.JobPostDetails.ApplyProcess;
            jobDetails.JobLocation = model.JobPostDetails.JobLocation;
            jobDetails.DeadLine = model.JobPostDetails.DeadLine;

            unitOfWork.JobPostRepository.Update(jobDetails, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Job Details Updated successfully!";

            return RedirectToAction("JobPostDetails", new { @jobId = model.JobPostDetails.JobCode });
        }
        public async Task<IActionResult> Delete(long Id)
        {
            if (Id > 0)
            {
                unitOfWork.JobPostRepository.DeletePermanantly(await unitOfWork.JobPostRepository.GetAsync(x => x.Id == Id));
                await unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index", "Job");
            }
            return BadRequest("Job ID must be greater than 0");
        }
    }
}