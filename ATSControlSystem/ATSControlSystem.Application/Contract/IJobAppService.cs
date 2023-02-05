using ATSControlSystem.Application.Models.Request;
using ATSControlSystem.Application.Models.Response;

namespace ATSControlSystem.Application.Contract;

public interface IJobAppService
{
    public GetJobResponseDto Create(CreateJobRequestDto createJobDto);
    
    public GetJobResponseDto GetById(string id);
    
    public void Delete(string id);

    public IEnumerable<GetJobResponseDto> GetAll();
    
    public GetJobResponseDto Update(UpdateJobRequestDto updateJobRequestDto);
}