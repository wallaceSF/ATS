namespace ATSControlSystem.Api.Models.Request;

public class UpdateJobRequest
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Seniority { get; set; }

    public decimal Salary { get; set; }
}