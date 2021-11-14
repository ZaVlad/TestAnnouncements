using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAnnouncements.Models.RequestModels;
using TestAnnouncements.Models.ViewModels;
using UseCases.Announcements.Commands.Create;
using UseCases.Announcements.Queries.GetList;
using UseCases.Models;

namespace TestAnnouncements.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly ISender _sender;
        public AnnouncementsController(ISender sender)
        {
            _sender = sender ??throw new ArgumentNullException(nameof(sender));
        }

        //Get: /Announcements/GetList
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var announcementsDtos = await _sender.Send(new GetAnnouncementsListQuery());
            var announcementsViewModels = announcementsDtos.Select(s => s.AsViewModel());
            return View(announcementsViewModels);
        }

        //Get: /Announcements/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Post: /Announcements/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnnouncementRequestModel requestModel)
        {
            ValidateAnnouncementRequest(requestModel);
            if(ModelState.IsValid == false)
            {
                return View(requestModel);
            }
            await _sender.Send(new CreateAnnouncementCommand() {AnnouncementDto = new CreateAnnouncementDto() 
            {Description = requestModel.Description,Title = requestModel.Title } });
            return RedirectToAction("GetList");
        }

        private void ValidateAnnouncementRequest(IAnnouncementRequest request)
        {
            if(request.Description is null)
            {
                ModelState.AddModelError($"{nameof(request.Description)}", "You must fill description field");
            }
            if (request.Title is null)
            {
                ModelState.AddModelError($"{nameof(request.Title)}", "You must fill title field");
            }
        }
    }
}
