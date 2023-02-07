using ATSControlSystem.Application.Models.Request;
using ATSControlSystem.Application.Service;
using ATSControlSystem.Application.Tests.Common;
using ATSControlSystem.Domain.Contract.Infrastruture.Repository;
using ATSControlSystem.Domain.Entity;
using Moq;
using Xunit;

namespace ATSControlSystem.Application.Tests;

public class CandidateAppServiceTest
{
    [Fact(DisplayName = "Should get candidate application service instance")]
    public void Should_Get_Candidate_Application_Service_Instance()
    {
        AutoMapperHelper.Load();

        var candidate = new Candidate(
            "John",
            "Wayne",
            DateTime.UtcNow,
            "john@teste.com",
            "123456",
            "It Developer Junior",
            "Resume test");


        var mock = new Mock<ICandidateRepository>();
        mock.Setup(m => m.Get(It.IsAny<string>()))
            .Returns(() => candidate);

        var candidateAppService = new CandidateAppService(mock.Object);

        var getCandidateResponseDto = candidateAppService.GetById("can_1q2w3e4r5t6y");

        Assert.Equal("123456", getCandidateResponseDto.Document);
        Assert.IsType<DateTime>(getCandidateResponseDto.BirthDate);
        Assert.Equal("john@teste.com", getCandidateResponseDto.Email);
        Assert.Equal("John", getCandidateResponseDto.FirstName);
        Assert.Contains("can_", getCandidateResponseDto.Id);
        Assert.Equal("Wayne", getCandidateResponseDto.LastName);
        Assert.Equal("It Developer Junior", getCandidateResponseDto.Occupation);
        Assert.Equal("Resume test", getCandidateResponseDto.Resume);
    }

    [Fact(DisplayName = "Should create candidate application service instance")]
    public void Should_Create_Candidate_Application_Service_Instance()
    {
        AutoMapperHelper.Load();

        var candidateRequestDto = new CreateCandidateRequestDto()
        {
            Occupation = "It Developer Junior",
            BirthDate = DateTime.UtcNow,
            FirstName = "John",
            LastName = "Wayne",
            Email = "john@teste.com",
            Document = "123456",
            Resume = "Resume test"
        };

        var candidate = new Candidate(
            "John",
            "Wayne",
            DateTime.UtcNow,
            "john@teste.com",
            "123456",
            "It Developer Junior",
            "Resume test");

        var mock = new Mock<ICandidateRepository>();
        mock.Setup(m => m.Upsert(It.IsAny<Candidate>()))
            .Returns(() => candidate);

        var candidateAppService = new CandidateAppService(mock.Object);

        var getCandidateResponseDto = candidateAppService.Create(candidateRequestDto);

        Assert.Equal("123456", getCandidateResponseDto.Document);
        Assert.IsType<DateTime>(getCandidateResponseDto.BirthDate);
        Assert.Equal("john@teste.com", getCandidateResponseDto.Email);
        Assert.Equal("John", getCandidateResponseDto.FirstName);
        Assert.Contains("can_", getCandidateResponseDto.Id);
        Assert.Equal("Wayne", getCandidateResponseDto.LastName);
        Assert.Equal("It Developer Junior", getCandidateResponseDto.Occupation);
        Assert.Equal("Resume test", getCandidateResponseDto.Resume);
    }

    [Fact(DisplayName = "Should get all candidates application service instance")]
    public void Should_Get_All_Candidates_Application_Service_Instance()
    {
        AutoMapperHelper.Load();

        var candidateList = new[] { "mock1", "mock2" }.Select(
                mockString => new Candidate(
                    $"John {mockString}",
                    $"Wayne {mockString}",
                    DateTime.UtcNow,
                    $"john@{mockString}.com",
                    "123456",
                    $"It Developer Junior {mockString}",
                    $"Resume test {mockString}"))
            .ToList();


        var mock = new Mock<ICandidateRepository>();
        mock.Setup(m => m.GetAll())
            .Returns(() => candidateList);

        var candidateAppService = new CandidateAppService(mock.Object);

        var getCandidateResponseDtos = candidateAppService.GetAll().ToList();

        Assert.Equal("123456", getCandidateResponseDtos[0].Document);
        Assert.IsType<DateTime>(getCandidateResponseDtos[0].BirthDate);
        Assert.Equal("john@mock1.com", getCandidateResponseDtos[0].Email);
        Assert.Equal("John mock1", getCandidateResponseDtos[0].FirstName);
        Assert.Contains("can_", getCandidateResponseDtos[0].Id);
        Assert.Equal("Wayne mock1", getCandidateResponseDtos[0].LastName);
        Assert.Equal("It Developer Junior mock1", getCandidateResponseDtos[0].Occupation);
        Assert.Equal("Resume test mock1", getCandidateResponseDtos[0].Resume);

        Assert.Equal("123456", getCandidateResponseDtos[1].Document);
        Assert.IsType<DateTime>(getCandidateResponseDtos[1].BirthDate);
        Assert.Equal("john@mock2.com", getCandidateResponseDtos[1].Email);
        Assert.Equal("John mock2", getCandidateResponseDtos[1].FirstName);
        Assert.Contains("can_", getCandidateResponseDtos[1].Id);
        Assert.Equal("Wayne mock2", getCandidateResponseDtos[1].LastName);
        Assert.Equal("It Developer Junior mock2", getCandidateResponseDtos[1].Occupation);
        Assert.Equal("Resume test mock2", getCandidateResponseDtos[1].Resume);
    }
}