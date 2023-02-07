using ATSControlSystem.Application.Contract;
using ATSControlSystem.Application.Extensions;
using ATSControlSystem.Application.Models.Request;
using ATSControlSystem.Api.Models;
using ATSControlSystem.Api.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace ATSControlSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobAppService _jobAppService;

    public JobController(IJobAppService jobAppService)
    {
        _jobAppService = jobAppService;
    }

    [HttpPost]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult CreateJob([FromBody] CreateJobRequest createJobRequest)
    {
        var createJobRequestDto = createJobRequest.Map<CreateJobRequestDto>();

        var getJobResponseDto = _jobAppService.Create(createJobRequestDto);

        return Ok(getJobResponseDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult UpdateJob(string id, [FromBody] UpdateJobRequest updateJobRequest)
    {
        var updateJobRequestDto = updateJobRequest.Map<UpdateJobRequestDto>();
        updateJobRequestDto.Id = id;
        
        var getJobResponseDto = _jobAppService.Update(updateJobRequestDto);

        return Ok(getJobResponseDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult GetJob(string id)
    {
        var job = _jobAppService.GetById(id);
        return Ok(job);
    }

    [HttpGet]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult GetAllJobs()
    {
        var job = _jobAppService.GetAll();
        return Ok(job);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(302)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public IActionResult DeleteJob(string id)
    {
        _jobAppService.Delete(id);
        return Ok();
    }
}