using Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class BannerViewModel
    {
        public int Id { get; set; }
        public PageDto Page { get; set; }
        public ImageDto Image { get; set; }
    }
}
