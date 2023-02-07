using ATSControlSystem.Application.Models.Request;
using ATSControlSystem.Application.Models.Response;
using ATSControlSystem.Domain.Entity;

namespace ATSControlSystem.Application.Models.Profile;

public class MapperBuild : AutoMapper.Profile
{
    public MapperBuild()
    {
        this.CreateMap<UpdateJobRequestDto, Job>();
        this.CreateMap<Job, GetJobResponseDto>();
        this.CreateMap<Candidate, GetCandidateResponseDto>();
    }
}