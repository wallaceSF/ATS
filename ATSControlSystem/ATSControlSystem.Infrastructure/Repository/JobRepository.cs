using ATSControlSystem.Domain.Contract.Infrastruture.Repository;
using ATSControlSystem.Domain.Entity;
using MongoDB.Driver;

namespace ATSControlSystem.Infrastructure.Repository;

public class JobRepository : BaseRepository<Job>, IJobRepository
{
    private readonly IMongoCollection<Job> _job;

    public JobRepository(IMongoCollection<Job> job) : base(job)
    {
        _job = job;
    }
}
