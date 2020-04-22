using System.Threading.Tasks;

namespace Compeng.MongoDB
{
    public interface IMongoDbContext
    {
         Task Insert<TEntity>(TEntity entity) where TEntity : LogBase;
         Task Update<TEntity>(TEntity entity) where TEntity : LogBase;
    }
}