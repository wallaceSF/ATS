namespace ATSControlSystem.Domain.Entity;

public class Job : BaseEntity
{
    
    public string Title { get; set; }

    public string Description { get; set; }

    public string Seniority { get; set; }

    public decimal Salary { get; set; }
    
    public Job()
    {
    }

    public Job(string title, string description, string seniority, decimal salary)
    {
        Id = Code.Create("job_");
        Title = title;
        Description = description;
        Seniority = seniority;
        Salary = salary;
    }
}