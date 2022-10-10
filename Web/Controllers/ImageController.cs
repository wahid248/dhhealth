using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Core.Abstruct.Base;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _config;

        public string SecretAccessKey { get; private set; }
        public string AccessKey { get; private set; }
        public string BucketName { get; private set; }

        public ImageController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            _config = config;

             SecretAccessKey = _config.GetValue<string>("AWS:SecretAccessKey");
             AccessKey = _config.GetValue<string>("AWS:AccessKey");
             BucketName = _config.GetValue<string>("AWS:Bucket:Name");
        }

        public async Task<IActionResult> Index()
        {
            var model = new ImageListViewModel()
            {
                Images = await GetSelectedImageList(),
                Albums = await GetAllAlbums(),
                SuccessMessage = TempData["SuccessMessage"] as string
            };

            return View(model);
        }

        public async Task<IEnumerable<ImageViewModel>> GetAllAlbums()
        {
            return (await unitOfWork.ImageRepository.GetAllAlbumsAsync()).Select(a => new ImageViewModel()
            {
                Id = a.Id,
                Album = a.Album
            }).ToList();
        }
        
        public async Task<IEnumerable<ImageViewModel>> GetSelectedImageList(string Album = "Home")
        {
            return (await unitOfWork.ImageRepository.GetAllImgSelectedAlbumAsync(Album))?.Select(a => new ImageViewModel()
            {
                Id = a.Id,
                ImageUrl = a.ImageUrl,
                BottomText = a.BottomText

            }).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbumAsync(ImageListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Failed to Create", "Please fill all the fields correctly");
                return View(model);
            }
            var data = new Core.Entities.Image()
            {
                Album = model.Image.Album
            };

            await unitOfWork.ImageRepository.AddAsync(data, userManager.GetUserId(User));
            await unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Album created successfully!";

            return RedirectToAction("Index");
        }

        #region Amazon

        [HttpPost]
        public async Task<IActionResult> AddImageAsync(IFormFile selectedFile, ImageListViewModel model)
        {

            var imageUrl = await UploadFileToAWSAsync(selectedFile, model.Image.Album);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Failed to Create", "Please fill all the fields correctly");
                return View(model);
            }
            var image = unitOfWork.ImageRepository.Get(x => x.Album == model.Image.Album);
            if (image.ImageUrl == null)
            {
                image.ImageUrl = imageUrl;
                image.BottomText = model.Image.BottomText;

                unitOfWork.ImageRepository.Update(image, userManager.GetUserId(User));
                await unitOfWork.SaveChangesAsync();
            }
            else
            {
                var data = new Core.Entities.Image()
                {
                    ImageUrl = imageUrl,
                    BottomText = model.Image.BottomText,
                    Album = model.Image.Album
                };

                await unitOfWork.ImageRepository.AddAsync(data, userManager.GetUserId(User));
                await unitOfWork.SaveChangesAsync();
            }
            

            TempData["SuccessMessage"] = "Image Added to Album successfully!";
            
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var image = await unitOfWork.ImageRepository.GetAsync(x => x.Id == Id);
            
            var imagePath = image.ImageUrl.Split('/').Last();
            imagePath = image.Album + "/" + imagePath;
            var deleteFromS3 = await DeleteFileFromAWSAsync(imagePath);

            if (Id > 0 && deleteFromS3.Item1)
            {
                unitOfWork.ImageRepository.DeletePermanantly(image);
                await unitOfWork.SaveChangesAsync();
                TempData["SuccessMessage"] = "Image Deleted successfully!";

                return RedirectToAction("Index");
            }
            else
            {
                return StatusCode(500, deleteFromS3.Item2);
            }
        }
        protected async Task<string> UploadFileToAWSAsync(IFormFile file, string album)
        {
            
            var result = "";

            try
            {
                using var s3Client = new AmazonS3Client(AccessKey, SecretAccessKey, Amazon.RegionEndpoint.APSoutheast1);
                var keyName = album + "/" + file.FileName;


                var fs = file.OpenReadStream();
                var request = new Amazon.S3.Model.PutObjectRequest
                {
                    BucketName = BucketName,
                    Key = keyName,
                    InputStream = fs,
                    ContentType = file.ContentType,
                    CannedACL = S3CannedACL.PublicRead
                };
                await s3Client.PutObjectAsync(request);

                result = string.Format("http://{0}.s3.amazonaws.com/{1}", BucketName, keyName);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        protected async Task<(bool, string)> DeleteFileFromAWSAsync(string filename)
        {           
            try
            {
                using var s3Client = new AmazonS3Client(AccessKey, SecretAccessKey, Amazon.RegionEndpoint.APSoutheast1);
                var bucketName = BucketName;
                var keyName = filename;

                var response = await s3Client.DeleteObjectAsync(bucketName, keyName);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
                    return (true, string.Empty);
                return (false, $"Image server returned {response.HttpStatusCode.ToString()}");

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        #endregion

    }
}