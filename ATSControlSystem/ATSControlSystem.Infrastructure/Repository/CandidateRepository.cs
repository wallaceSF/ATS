using ATSControlSystem.Domain.Contract.Infrastruture.Repository;
using ATSControlSystem.Domain.Entity;
using MongoDB.Driver;

namespace ATSControlSystem.Infrastructure.Repository;

public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
{
    private readonly IMongoCollection<Candidate> _candidate;

    public CandidateRepository(IMongoCollection<Candidate> candidate) : base(candidate)
    {
        _candidate = candidate;
    }
}
