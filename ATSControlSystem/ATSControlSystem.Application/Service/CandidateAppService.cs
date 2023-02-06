using System.Collections.Generic;
using ATSControlSystem.Application.Extensions;
using ATSControlSystem.Application.Contract;
using ATSControlSystem.Application.Models.Request;
using ATSControlSystem.Application.Models.Response;
using ATSControlSystem.Domain.Contract.Infrastruture.Repository;
using ATSControlSystem.Domain.Entity;
using ATSControlSystem.Domain.Exceptions;
using FluentValidation;

namespace ATSControlSystem.Application.Service;

public class CandidateAppService : ICandidateAppService
{
    private readonly ICandidateRepository _candidateRepository;

    public CandidateAppService(ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
    }

    public GetCandidateResponseDto Create(CreateCandidateRequestDto createCandidateDto)
    {
        var isValid = createCandidateDto.Validate(out var error);

        if (!isValid)
        {
            throw new ValidationException(error);
        }

        var candidate = new Candidate(
            createCandidateDto.FirstName,
            createCandidateDto.LastName,
            createCandidateDto.BirthDate,
            createCandidateDto.Email,
            createCandidateDto.Document,
            createCandidateDto.Occupation,
            createCandidateDto.Resume
        );

        var candidateUpdated = _candidateRepository.Upsert(candidate);
        return candidateUpdated.Map<GetCandidateResponseDto>();
    }

    public GetCandidateResponseDto GetById(string id)
    {
        var candidate = _candidateRepository.Get(id);

        if (candidate == null)
        {
            throw new PreconditionFailedException("Candidate not found");
        }

        return candidate.Map<GetCandidateResponseDto>();
    }

    public IEnumerable<GetCandidateResponseDto> GetAll()
    {
        var candidateList = _candidateRepository.GetAll();

        if (candidateList == null)
        {
            throw new PreconditionFailedException("Candidates not found");
        }

        return candidateList.Map<IEnumerable<GetCandidateResponseDto>>();
    }

    public GetCandidateResponseDto Update(UpdateCandidateRequestDto updateCandidateRequestDto)
    {
        var candidate = _candidateRepository.Get(updateCandidateRequestDto.Id);
        
        if (candidate == null)
        {
            throw new PreconditionFailedException("Candidate not found");
        }
        
        var isValid = updateCandidateRequestDto.Validate(out var error);

        if (!isValid)
        {
            throw new ValidationException(error);
        }

        candidate.UpdateProfile(updateCandidateRequestDto);

        var candidateUpdated = _candidateRepository.Upsert(candidate);

        return candidateUpdated.Map<GetCandidateResponseDto>();
    }

    public void Delete(string id)
    {
        var candidate = _candidateRepository.Get(id);

        if (candidate == null)
        {
            throw new PreconditionFailedException("Candidate not found");
        }
        
        _candidateRepository.Delete(id);
    }
}