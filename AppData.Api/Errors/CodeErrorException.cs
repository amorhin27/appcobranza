namespace AppData.Api.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; }
        public CodeErrorException(bool success, int statusCode, string? message = null, string? details = null) : base(success, statusCode, message)
        {
            Details = details;
        }
    }
}
