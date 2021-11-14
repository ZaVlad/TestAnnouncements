using Infrastructure.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Announcements.Commands.Delete
{
    class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommand, bool>
    {
        private readonly IDbContext _dbContext;
        public DeleteAnnouncementCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = await _dbContext.Announcement.FindAsync(request.Id);
            _dbContext.Announcement.Remove(announcement);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
