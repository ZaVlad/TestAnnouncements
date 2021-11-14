using AutoMapper;
using Entities;
using Infrastructure.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Announcements.Commands.Create
{
    class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, bool>
    {
        private readonly IDbContext _dbContext;
        public CreateAnnouncementCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<bool> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = new Announcement()
            {
                DateAdded = DateTime.Now,
                Description = request.AnnouncementDto.Description,
                Title = request.AnnouncementDto.Title
            };
            await _dbContext.Announcement.AddAsync(announcement);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
