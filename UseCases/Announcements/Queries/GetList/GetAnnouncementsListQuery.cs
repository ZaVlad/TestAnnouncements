using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Announcements.Queries.GetList
{
    public class GetAnnouncementsListQuery :IRequest<List<AnnouncementDto>>
    {
    }
}
