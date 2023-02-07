using System;
using ATSControlSystem.Domain.Exceptions;
using Xunit;

namespace ATSControlSystem.Domain.Tests.Exceptions;

public class DomainExceptionTest
{
    [Fact(DisplayName = "Should create throw exception with custom message")]
    public void Should_Create_Throw_exception_with_custom_message()
    {
        var x = new DomainException("teste exception");

        Assert.Equal("teste exception", x.Message);
        Assert.IsType<DomainException>(x);
    }

    [Fact(DisplayName = "Should create throw exception")]
    public void Should_Create_Throw_exception()
    {
        var x = new DomainException();

        Assert.Contains("'ATSControlSystem.Domain.Exceptions.DomainException' was thrown.", x.Message);
        Assert.IsType<DomainException>(x);
    }

    [Fact(DisplayName = "Should create throw exception with inner exception")]
    public void Should_Create_Throw_exception_with_inner_exception()
    {
        var x = new DomainException("inner exception test", new Exception("teste"));

        Assert.Contains("inner exception test", x.Message);
        Assert.IsType<DomainException>(x);
    }
}