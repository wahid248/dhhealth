using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Enums.SectionType
{
    public enum SectionTypes
    {
        [Display(Name = "Simple Card")] SimpleCard = 1,
        [Display(Name = "Card With Background")] CardWithBackground,
        [Display(Name = "Card Without Background")] CardWithOutBackground,
        [Display(Name = "News Card-2")] NewsCard2,
        [Display(Name = "Home Gallery Card")] HomeGalleryCard,
        [Display(Name = "Brand Card")] BrandCard,
        [Display(Name = "Banner Content")] BannerContent,
        [Display(Name = "Contact Info")] ContactInfo
    }
}
