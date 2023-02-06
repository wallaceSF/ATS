using System;

namespace ATSControlSystem.Domain.Exceptions
{
    public class PreconditionFailedException : DomainException
    {

        public PreconditionFailedException()
        {
        }

        public PreconditionFailedException(string message)
            : base(message)
        {
        }

        public PreconditionFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public PreconditionFailedException(string message, string code, params string[] errors)
            : base(message)
        {
            this.Code = code;
            this.Errors = errors;
        }

        public string Code { get; set; }

        public string[] Errors { get; set; }
    }
}