using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.interfaces
{
    public interface IDbContext 
    {
        public DbSet<Announcement> Announcement { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
