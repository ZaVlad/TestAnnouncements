using Entities;
using Infrastructure.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Announcements.Queries.GetDetail
{
    class GetAnnouncemetDetailHandler : IRequestHandler<GetAnnouncemetDetailQuery, AnnouncementDetailDto>
    {
        private readonly IDbContext _dbContext;
        public GetAnnouncemetDetailHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<AnnouncementDetailDto> Handle(GetAnnouncemetDetailQuery request, CancellationToken cancellationToken)
        {
            var announcement = await _dbContext.Announcement.FindAsync(request.id);
            string[] titleElemnts = announcement.Title.Split(' ');
            List<Announcement> announcements = new List<Announcement>();
            foreach (var item in _dbContext.Announcement.OrderBy(s=>s.Id))
            {
                if(item.Id == announcement.Id)
                {
                    continue;
                }
                bool result = false;
                foreach (var element in titleElemnts)
                {
                    result = item.Title.Contains(element);
                    if (result)
                    {
                        break;
                    }
                }
                if (result)
                {
                    announcements.Add(item);
                    result = false;
                }
                if(announcements.Count == 3)
                {
                    break;
                }
            }
            return new AnnouncementDetailDto()
            {
                Id = announcement.Id,
                DateAdded = announcement.DateAdded,
                Description = announcement.Description,
                Title = announcement.Title,
                SameAnnouncements = announcements.Select(s => s.Title).ToList()
            };
        }
    }
}
