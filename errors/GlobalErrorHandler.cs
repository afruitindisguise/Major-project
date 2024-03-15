using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Major_Project.errors{
    public class GlobalErrorHandler : IExceptionHandler{
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken){
            ErrorDetails errorDetails = new ErrorDetails();
            if (exception is UserNameNotFoundError){
                errorDetails.StatusCode = (int)HttpStatusCode.NotFound;
                errorDetails.Message = "Username not found";
                errorDetails.ExceptionMessage = exception.Message;
            }else{
                errorDetails.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorDetails.Message = "Something went wrong";
                errorDetails.ExceptionMessage = exception.Message;
            }
            httpContext.Response.StatusCode = errorDetails.StatusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(errorDetails, cancellationToken);
            return true;
        }
    }
}