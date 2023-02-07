using ATSControlSystem.Application.Contract;
using ATSControlSystem.Application.Extensions;
using ATSControlSystem.Application.Models.Request;
using ATSControlSystem.Api.Models;
using ATSControlSystem.Api.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace ATSControlSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidateController : ControllerBase
{
    private readonly ICandidateAppService _candidateAppService;

    public CandidateController(ICandidateAppService candidateAppService)
    {
        _candidateAppService = candidateAppService;
    }

    [HttpPost]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult CreateCandidate([FromBody] CreateCandidateRequest createCandidateRequest)
    {
        var createCandidateRequestDto = createCandidateRequest.Map<CreateCandidateRequestDto>();

        var getCandidateResponseDto = _candidateAppService.Create(createCandidateRequestDto);

        return Ok(getCandidateResponseDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCandidate(string id, [FromBody] UpdateCandidateRequest updateCandidateRequest)
    {
        var updateCandidateRequestDto = updateCandidateRequest.Map<UpdateCandidateRequestDto>();
        updateCandidateRequestDto.Id = id;
        
        var getCandidateResponseDto = _candidateAppService.Update(updateCandidateRequestDto);

        return Ok(getCandidateResponseDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult GetCandidate(string id)
    {
        var candidate = _candidateAppService.GetById(id);
        return Ok(candidate);
    }

    [HttpGet]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult GetAllCandidates()
    {
        var candidate = _candidateAppService.GetAll();
        return Ok(candidate);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult DeleteCandidate(string id)
    {
        _candidateAppService.Delete(id);
        return Ok();
    }
}