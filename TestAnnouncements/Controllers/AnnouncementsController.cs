using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAnnouncements.Models.RequestModels;
using TestAnnouncements.Models.ViewModels;
using UseCases.Announcements.Commands.Create;
using UseCases.Announcements.Commands.Delete;
using UseCases.Announcements.Commands.Update;
using UseCases.Announcements.Queries.Get;
using UseCases.Announcements.Queries.GetDetail;
using UseCases.Announcements.Queries.GetList;
using UseCases.Models;

namespace TestAnnouncements.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly ISender _sender;
        public AnnouncementsController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        //Get: /Announcements/GetList
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var announcementsDtos = await _sender.Send(new GetAnnouncementsListQuery());
            var announcementsViewModels = announcementsDtos.Select(s => s.AsViewModel());
            return View(announcementsViewModels);
        }
        [HttpGet]

        //Get: /Announcements/GetDetail/{id}    
        public async Task<IActionResult> GetDetail(int id)
        {
            var detailAnnouncement = await _sender.Send(new GetAnnouncemetDetailQuery() 
            { id = id });
            return View(detailAnnouncement.AsViewModel());
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
            if (ModelState.IsValid == false)
            {
                return View(requestModel);
            }
            await _sender.Send(new CreateAnnouncementCommand()
            {
                AnnouncementDto = new CreateAnnouncementDto()
                { Description = requestModel.Description, Title = requestModel.Title }
            });
            return RedirectToAction("GetList");
        }

        // Get: /Announcements/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var announcement = await _sender.Send(new GetAnnouncementQuery() { Id= id });
            return View(new EditAnnouncementRequestModel() 
            {Description = announcement.Description,
                Title = announcement.Title });
        }

        //Put: /Announcements/Edit/{id}
        [HttpPut]
        public async Task<IActionResult> Edit(int id, EditAnnouncementRequestModel request)
        {

            ValidateAnnouncementRequest(request);

            if (ModelState.IsValid == false)
            {
                return View(request);
            }

            await _sender.Send(new UpdateAnnouncementCommand()
            {
                UpdatedAnnouncement = new UpdateAnnouncementDto()
                {
                    Id = id,
                    Description = request.Description,
                    Title = request.Title
                }
            });
            return RedirectToAction("GetList");
        }
        //Get: /Announcements/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var announcement = await _sender.Send(new GetAnnouncementQuery() { Id = id });
            return View(announcement.AsViewModel());
        }
        //Post: /Announcements/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id,IFormCollection collection)
        {
            await _sender.Send(new DeleteAnnouncementCommand() { Id = id});
            return RedirectToAction("GetList");
        }

        private void ValidateAnnouncementRequest(IAnnouncementRequest request)
        {
            if (request.Description is null)
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
