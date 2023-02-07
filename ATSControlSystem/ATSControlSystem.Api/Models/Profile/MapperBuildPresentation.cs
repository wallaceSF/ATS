using ATSControlSystem.Api.Models.Request;
using ATSControlSystem.Application.Models.Request;
using ATSControlSystem.Application.Models.Response;
using ATSControlSystem.Domain.Entity;

namespace ATSControlSystem.Api.Models.Profile;

public class MapperBuildPresentation : AutoMapper.Profile
{
    public MapperBuildPresentation()
    {
        this.CreateMap<CreateJobRequest, CreateJobRequestDto>();
        this.CreateMap<UpdateJobRequest, UpdateJobRequestDto>();
      
        this.CreateMap<UpdateJobRequestDto, Job>();
        this.CreateMap<Job, GetJobResponseDto>();
        this.CreateMap<CreateCandidateRequest, CreateCandidateRequestDto>();
        this.CreateMap<Candidate, GetCandidateResponseDto>();
        this.CreateMap<UpdateCandidateRequest, UpdateCandidateRequestDto>();
    }
}