using PersonalProject.Domain;
using System.Threading.Tasks;

namespace PersonalProject.Repository
{
    public class DbContextHandler : IDbContextHandler
    {
        private readonly UPDbContext _dbContext;

        public DbContextHandler(UPDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
