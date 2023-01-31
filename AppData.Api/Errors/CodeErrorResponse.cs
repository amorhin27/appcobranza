namespace AppData.Api.Errors
{
    public class CodeErrorResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public CodeErrorResponse(bool success, int statusCode, string? message = null)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Request enviado tiene errores",
                401 => "No tienes authorizacion para este recurso",
                404 => "No se encontro el recurso solicitado",
                500 => "Se producieron errores en el servidor",
                302 => "No comple con criterios de aceptación",
                _ => string.Empty
            };
        }
    }
}
