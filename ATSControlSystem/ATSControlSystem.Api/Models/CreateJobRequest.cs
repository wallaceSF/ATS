﻿namespace ATSControlSystem.Api.Models;

public class CreateJobRequest
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Seniority { get; set; }

    public decimal Salary { get; set; }
}