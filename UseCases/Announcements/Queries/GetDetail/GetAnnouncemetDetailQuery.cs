using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Announcements.Queries.GetDetail
{
    public class GetAnnouncemetDetailQuery:IRequest<AnnouncementDetailDto>
    {
        public int id { get; set; }
    }
}
