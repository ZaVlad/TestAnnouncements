using Infrastructure.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Announcements.Commands.Update
{
    class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommand, bool>
    {
        private readonly IDbContext _dbContext;
        public UpdateAnnouncementCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<bool> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = await _dbContext.Announcement.FindAsync(request.UpdatedAnnouncement.Id);
            announcement.Description = request.UpdatedAnnouncement.Description;
            announcement.Title = request.UpdatedAnnouncement.Title;
            announcement.DateAdded = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
