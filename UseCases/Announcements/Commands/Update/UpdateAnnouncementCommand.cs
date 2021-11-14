using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Announcements.Commands.Update
{
   public class UpdateAnnouncementCommand:IRequest<bool>
    {
        public UpdateAnnouncementDto UpdatedAnnouncement { get; set; }
    }
}
