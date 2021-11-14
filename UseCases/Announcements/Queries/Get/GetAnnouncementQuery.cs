using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Announcements.Queries.Get
{
    public class GetAnnouncementQuery:IRequest<AnnouncementDto>
    {
        public int Id { get; set; }
    }
}
