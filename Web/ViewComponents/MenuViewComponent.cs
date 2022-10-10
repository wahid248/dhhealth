using Core.Abstruct.Base;
using Data.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pages = await _unitOfWork.PageRepository.GetAllPages();
            var model = pages.Select(p => new PageViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Controller = p.ControllerName,
                Action = p.ActionName,
                IsEnabled = p.IsEnabled
            }).ToList();

            return View("~/Views/Components/Menu.cshtml", model);
        }
    }
}
