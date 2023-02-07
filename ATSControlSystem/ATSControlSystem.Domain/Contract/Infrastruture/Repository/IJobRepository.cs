using ATSControlSystem.Domain.Entity;

namespace ATSControlSystem.Domain.Contract.Infrastruture.Repository;

public interface IJobRepository
{
    Job Get(string id);
    
    Job Upsert(Job job);

    public IEnumerable<Job> GetAll();

    public void Delete(string id);
}