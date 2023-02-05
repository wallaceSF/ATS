using ATSControlSystem.Domain.Contract.Application;

namespace ATSControlSystem.Domain.Entity;

public class Candidate : BaseEntity
{
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public DateTime BirthDate { get; init; }
    
    public string Email { get; set; }
    
    public string Occupation { get; set; }
    
    public string Document { get; set; }
   

    public string Resume { get; set; }

    public Candidate()
    {
    }

    public Candidate(string firstName, string lastName, DateTime birthDate, string email, string document, string occupation)
    {
        Id = Code.Create("can_");
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Document = document;
        Email = email;
        Occupation = occupation;
    }

    public Candidate(string firstName, string lastName, DateTime birthDate, string email,  string document, string occupation,
        string resume)
    {
        Id = Code.Create("can_");
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Document = document;
        Email = email;
        Occupation = occupation;
        Resume = resume;
    }

    public void UpdateProfile(IUpdateCandidateProfileDto updateCandidateRequestDto)
    {
        Occupation = updateCandidateRequestDto.Occupation;
        Email = updateCandidateRequestDto.Email;
        Document = updateCandidateRequestDto.Document;
        Resume = updateCandidateRequestDto.Resume;
    }
}