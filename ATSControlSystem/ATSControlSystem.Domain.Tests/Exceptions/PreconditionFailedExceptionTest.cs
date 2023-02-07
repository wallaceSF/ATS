using ATSControlSystem.Domain.Exceptions;
using Xunit;

namespace ATSControlSystem.Domain.Tests.Exceptions;

public class PreconditionFailedExceptionTest
{
    [Fact(DisplayName = "Should create throw precondition failed exception")]
    public void Should_Create_Throw_Precondition_Failed_Exception()
    {
        var x = new PreconditionFailedException("test precondition failed exception");

        Assert.Equal("test precondition failed exception", x.Message);
        Assert.IsType<PreconditionFailedException>(x);
    }
}