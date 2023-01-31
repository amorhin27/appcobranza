using AppData.Api.Errors;
using AppData.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace AppData.Api.Middlewore
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                bool success = false;
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(success, statusCode, ex.Message, validationJson));
                        break;

                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case BadValidacionException badValidacionException:
                        statusCode = (int)HttpStatusCode.Found;
                        break;

                    default:
                        break;
                }

                //var response = _env.IsDevelopment() 
                //    ? new CodeErrorException(true, (int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                //    : new CodeErrorException(true, (int)HttpStatusCode.InternalServerError);

                //var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                //var json = System.Text.Json.JsonSerializer.Serialize(response, options);
                //await context.Response.WriteAsync(json);


                if (string.IsNullOrEmpty(result))
                    result = JsonConvert.SerializeObject(new CodeErrorException(success, statusCode, ex.Message, ex.StackTrace));
                    //result = JsonConvert.SerializeObject(new CodeErrorException(success, statusCode, ex.Message, ex.Source)); //error capa de proyecto
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
