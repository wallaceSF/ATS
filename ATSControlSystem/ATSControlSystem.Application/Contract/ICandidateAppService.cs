using ATSControlSystem.Application.Models.Request;
using ATSControlSystem.Application.Models.Response;

namespace ATSControlSystem.Application.Contract;

public interface ICandidateAppService
{
    public GetCandidateResponseDto Create(CreateCandidateRequestDto createCandidateDto);
    
    public GetCandidateResponseDto GetById(string id);
    
    public void Delete(string id);

    public IEnumerable<GetCandidateResponseDto> GetAll();
    
    public GetCandidateResponseDto Update(UpdateCandidateRequestDto updateCandidateRequestDto);
}