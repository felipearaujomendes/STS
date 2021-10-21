using Microsoft.EntityFrameworkCore;
using STS.Domain.Interfaces;
using System.Threading.Tasks;

namespace STS.Infrastructure.Data.Contexts
{
    public class BaseDbContext : DbContext, IUnitOfWork
    {
        public BaseDbContext()
        {

        }
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
