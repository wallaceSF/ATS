using ATSControlSystem.Application.Extensions;
using ATSControlSystem.Application.Contract;
using ATSControlSystem.Application.Models.Request;
using ATSControlSystem.Application.Models.Response;
using ATSControlSystem.Domain.Contract.Infrastruture.Repository;
using ATSControlSystem.Domain.Entity;
using ATSControlSystem.Domain.Exceptions;
using FluentValidation;

namespace ATSControlSystem.Application.Service;

public class JobAppService : IJobAppService
{
    private readonly IJobRepository _jobRepository;

    public JobAppService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public GetJobResponseDto Create(CreateJobRequestDto createJobDto)
    {
        var isValid = createJobDto.Validate(out var error);

        if (!isValid)
        {
            throw new ValidationException(error);
        }

        var job = new Job(
            createJobDto.Title,
            createJobDto.Description,
            createJobDto.Seniority,
            createJobDto.Salary
        );

        var jobUpdated = _jobRepository.Upsert(job);
        return jobUpdated.Map<GetJobResponseDto>();
    }

    public GetJobResponseDto GetById(string id)
    {
        var job = _jobRepository.Get(id);

        if (job == null)
        {
            throw new PreconditionFailedException("Job not found");
        }

        return job.Map<GetJobResponseDto>();
    }

    public IEnumerable<GetJobResponseDto> GetAll()
    {
        var jobList = _jobRepository.GetAll();

        if (jobList == null)
        {
            throw new PreconditionFailedException("Jobs not found");
        }

        return jobList.Map<IEnumerable<GetJobResponseDto>>();
    }

    public GetJobResponseDto Update(UpdateJobRequestDto updateJobRequestDto)
    {
        var job = _jobRepository.Get(updateJobRequestDto.Id);
        
        var isValid = updateJobRequestDto.Validate(out var error);

        if (!isValid)
        {
            throw new ValidationException(error);
        }

        if (job == null)
        {
            throw new PreconditionFailedException("Job not found");
        }

        var jobUpdated = _jobRepository.Upsert(updateJobRequestDto.Map<Job>());

        return jobUpdated.Map<GetJobResponseDto>();
    }

    public void Delete(string id)
    {
        _jobRepository.Delete(id);
    }
}