using System;

namespace ATSControlSystem.Application.Models.Response;

public class GetCandidateResponseDto
{
    public string Id { get; set; }
    
    public string Occupation { get; set; }

    public DateTime BirthDate { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
    
    public string Document { get; set; }

    public string Resume { get; set; }
}