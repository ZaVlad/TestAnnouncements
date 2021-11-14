using AutoMapper;
using Infrastructure.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Announcements.Queries.Get
{
    class GetAnnouncementHandler : IRequestHandler<GetAnnouncementQuery, AnnouncementDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAnnouncementHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<AnnouncementDto> Handle(GetAnnouncementQuery request, CancellationToken cancellationToken)
        {
            var announcement = await _dbContext.Announcement.FindAsync(request.Id);
            return _mapper.Map<AnnouncementDto>(announcement);
        }
    }
}
