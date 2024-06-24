namespace SimetricaConsulting.Application.Exceptions
{
    public class ForbiddenException : ApplicationException
    {
        private const string message = "You are not authorized to access this resource.";

        public ForbiddenException() : base(message)
        {
        }
    }
}