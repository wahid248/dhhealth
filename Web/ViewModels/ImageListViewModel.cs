using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class ImageListViewModel
    {
        public ImageViewModel Image { get; set; }
        public string SuccessMessage { get; set; }

        public IEnumerable<ImageViewModel> Albums { get; set; }
        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
