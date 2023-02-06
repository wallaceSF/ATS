using System.Collections.Generic;
using ATSControlSystem.Domain.Entity;

namespace ATSControlSystem.Domain.Contract.Infrastruture.Repository;

public interface ICandidateRepository
{
    Candidate Get(string id);
    
    Candidate Upsert(Candidate job);

    public IEnumerable<Candidate> GetAll();

    public void Delete(string id);
}