﻿namespace ATSControlSystem.Api.Models;

public class UpdateCandidateRequest
{
    public string Occupation { get; set; }

    public string Email { get; set; }

    public string Document { get; set; }

    public string Resume { get; set; }
}