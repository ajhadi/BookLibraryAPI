using System.Net;

namespace BookLibraryAPI.DTOs
{
    public class ServiceResponse
    {
        public string? Message { get; set; }
        public bool Succeeded { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ServiceResponse() { }

        public ServiceResponse(string? message, bool succeeded, HttpStatusCode statusCode)
        {
            Message = message;
            Succeeded = succeeded;
            StatusCode = statusCode;
        }

        public static ServiceResponse Success(HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null)
        {
            return new ServiceResponse(message, true, statusCode);
        }

        public static ServiceResponse Failure(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string? message = null)
        {
            return new ServiceResponse(message, false, statusCode);
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T? Data { get; set; }

        public ServiceResponse() { }

        public ServiceResponse(T data, string? message, bool succeeded, HttpStatusCode statusCode)
            : base(message, succeeded, statusCode)
        {
            Data = data;
        }

        public static ServiceResponse<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null)
        {
            return new ServiceResponse<T>(data, message, true, statusCode);
        }

        public static new ServiceResponse<T> Failure(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string? message = null)
        {
            return new ServiceResponse<T>(default!, message, false, statusCode);
        }
    }
}
