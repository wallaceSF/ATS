using ATSControlSystem.Application.Extensions;
using ATSControlSystem.Application.Models.Profile;
using AutoMapper;

namespace ATSControlSystem.Application.Tests.Common;

public static class AutoMapperHelper
{
    public static void Load()
    {
        var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new MapperBuild()); });
        var mapper = mockMapper.CreateMapper();

        GlobalMapper.Mapper = mapper;
    }
}