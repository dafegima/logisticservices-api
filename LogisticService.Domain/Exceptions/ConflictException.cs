
namespace LogisticService.Domain.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string errorMessage) : base(errorMessage) { }
    }
}