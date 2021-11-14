using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Announcements.Commands.Delete
{
    public class DeleteAnnouncementCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
