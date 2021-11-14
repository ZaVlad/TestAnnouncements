using AutoMapper;
using Infrastructure.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Announcements.Queries.GetList
{
    class GetAnnouncementsListHandler : IRequestHandler<GetAnnouncementsListQuery, List<AnnouncementDto>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAnnouncementsListHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<AnnouncementDto>> Handle(GetAnnouncementsListQuery request, CancellationToken cancellationToken)
        {
            var announcements = await _dbContext.Announcement.ToListAsync();
            var announcementDtos=_mapper.Map<List<AnnouncementDto>>(announcements);
            return announcementDtos;
        }
    }
}
