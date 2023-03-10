using JellyFish.Models;
namespace JellyFish.Repository.IRepository
{
    public interface IJobRepository : IRepository<Job>
    {
        void Update(Job obj);
        
    }
}
