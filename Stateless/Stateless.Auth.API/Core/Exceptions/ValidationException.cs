namespace Stateless.Auth.API.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; }
        public override string Message { get; }
    }
}
