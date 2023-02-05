namespace ATSControlSystem.Application.Models.Response;

public class GetJobResponseDto
{
    public string Id { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }

    public string Seniority { get; set; }

    public decimal Salary { get; set; }
}