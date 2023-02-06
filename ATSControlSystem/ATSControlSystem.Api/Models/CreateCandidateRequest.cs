using System;

namespace ATSControlSystem.Api.Models;

public class CreateCandidateRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public DateTime BirthDate { get; set; }

    public string Email { get; set; }
    
    public string Document { get; set; }
    
    public string Occupation { get; set; }

    public string Resume { get; set; }
}