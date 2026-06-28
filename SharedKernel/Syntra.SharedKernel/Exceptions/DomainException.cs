namespace Syntra.SharedKernel.Exceptions
{
    public class DomainException : Exception
    {
        protected DomainException(string message) : base(message) { }
    }
}
