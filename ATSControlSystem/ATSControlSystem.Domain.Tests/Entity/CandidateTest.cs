using System;
using ATSControlSystem.Domain.Contract.Application;
using ATSControlSystem.Domain.Entity;
using Moq;
using Xunit;

namespace ATSControlSystem.Domain.Tests.Entity;

public class CandidateTest
{
    [Fact(DisplayName = "Should create candidate instance")]
    public void Should_Create_Candidate_Instance()
    {
        var candidate = new Candidate(
            "John",
            "Wayne",
            DateTime.UtcNow,
            "john@teste.com",
            "123456",
            "It Developer Junior"
        );

        Assert.Equal("John", candidate.FirstName);
        Assert.Equal("Wayne", candidate.LastName);
        Assert.IsType<DateTime>(candidate.BirthDate);
        Assert.Equal("john@teste.com", candidate.Email);
        Assert.Equal("123456", candidate.Document);
        Assert.Equal("It Developer Junior", candidate.Occupation);
        Assert.Contains("can_", candidate.Id);
    }
    
    [Fact(DisplayName = "Should create candidate instance with resume")]
    public void Should_Create_Candidate_Instance_With_Resume()
    {
        var candidate = new Candidate(
            "John",
            "Wayne",
            DateTime.UtcNow,
            "john@teste.com",
            "123456",
            "It Developer Junior",
            "Resume test");

        Assert.Equal("John", candidate.FirstName);
        Assert.Equal("Wayne", candidate.LastName);
        Assert.IsType<DateTime>(candidate.BirthDate);
        Assert.Equal("john@teste.com", candidate.Email);
        Assert.Equal("123456", candidate.Document);
        Assert.Equal("It Developer Junior", candidate.Occupation);
        Assert.Equal("Resume test", candidate.Resume);
        Assert.Contains("can_", candidate.Id);
    }

    [Fact(DisplayName = "Should update candidate profile")]
    public void Should_Update_Candidate_Profile()
    {
        var candidate = new Candidate(
            "John",
            "Wayne",
            DateTime.UtcNow,
            "john@teste.com",
            "123456",
            "It Developer Junior",
            "Resume test");

        var updateCandidateProfileDto = new Mock<IUpdateCandidateProfileDto>();
        
        updateCandidateProfileDto.SetupGet(x => x.Occupation).Returns("It Developer Senior");
        updateCandidateProfileDto.SetupGet(x => x.Email).Returns("john2@teste.com");
        updateCandidateProfileDto.SetupGet(x => x.Document).Returns("431456");
        updateCandidateProfileDto.SetupGet(x => x.Resume).Returns("Resume test update");

        candidate.UpdateProfile(updateCandidateProfileDto.Object);

        Assert.Equal("John", candidate.FirstName);
        Assert.Equal("Wayne", candidate.LastName);
        Assert.IsType<DateTime>(candidate.BirthDate);
        Assert.Equal("john2@teste.com", candidate.Email);
        Assert.Equal("431456", candidate.Document);
        Assert.Equal("It Developer Senior", candidate.Occupation);
        Assert.Equal("Resume test update", candidate.Resume);
        Assert.Contains("can_", candidate.Id);
    }
}