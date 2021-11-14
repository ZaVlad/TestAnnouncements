using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAnnouncements.Models.ViewModels;
using UseCases.Announcements.Queries.GetList;

namespace TestAnnouncements.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly ISender _sender;
        public AnnouncementsController(ISender sender)
        {
            _sender = sender;
        }
        public async Task<IActionResult> GetList()
        {
            var announcementsDtos = await _sender.Send(new GetAnnouncementsListQuery());
            var announcementsViewModels = announcementsDtos.Select(s => new AnnouncementViewModel()
            {
                DateAdded = s.DateAdded,
                Description = s.Description,
                Id = s.Id,
                Title = s.Title
            });
            return View(announcementsViewModels);
        }
    }
}
