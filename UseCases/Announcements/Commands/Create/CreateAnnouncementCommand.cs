using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Announcements.Commands.Create
{
    public class CreateAnnouncementCommand:IRequest<bool>
    {
        public CreateAnnouncementDto AnnouncementDto { get; set; }
    }
}
