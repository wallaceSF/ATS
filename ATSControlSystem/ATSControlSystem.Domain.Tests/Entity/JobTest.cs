using System;
using ATSControlSystem.Domain.Entity;
using Xunit;

namespace ATSControlSystem.Domain.Tests.Entity
{
    public class JobTest
    {
        [Fact(DisplayName = "Should create job instance")]
        public void Should_Create_Job_Instance()
        {
            var job = new Job("Software development", "little description", "Junior", 20000);

            Assert.Equal("Software development", job.Title);
            Assert.Equal("little description", job.Description);
            Assert.Equal("Junior", job.Seniority);
            Assert.Equal(20000, job.Salary);
            Assert.IsType<DateTime>(job.CreatedAt);
            Assert.IsType<DateTime>(job.UpdatedAt);
            Assert.Equal(20000, job.Salary);
            Assert.Contains("job_", job.Id);
        }
    }
}