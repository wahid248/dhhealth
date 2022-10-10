using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class ImageViewModel
    {
        public string ImageUrl { get; set; }
        public int Id { get; set; }
        public string BottomText { get; set; }
        public string Album { get; set; }
        public Section Section { get; set; }

        public int SectionId { get; set; }
    }
}
