using System.Threading.Tasks;

namespace PersonalProject.Domain
{
    public interface IDbContextHandler
    {
        Task SaveChangesAsync();
    }
}
