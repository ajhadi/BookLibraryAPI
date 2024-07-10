using System.Net;

namespace BookLibraryAPI.DTOs
{
    /// <summary>
    /// Represents a generic response from a service, including status, message, and HTTP status code.
    /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// Gets or sets a message providing additional information about the response.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the operation succeeded.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code associated with the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse"/> class.
        /// </summary>
        public ServiceResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse"/> class with the specified parameters.
        /// </summary>
        /// <param name="message">A message providing additional information about the response.</param>
        /// <param name="succeeded">A value indicating whether the operation succeeded.</param>
        /// <param name="statusCode">The HTTP status code associated with the response.</param>
        public ServiceResponse(string? message, bool succeeded, HttpStatusCode statusCode)
        {
            Message = message;
            Succeeded = succeeded;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Creates a successful <see cref="ServiceResponse"/> with an optional message and status code.
        /// </summary>
        /// <param name="statusCode">The HTTP status code (default is <see cref="HttpStatusCode.OK"/>).</param>
        /// <param name="message">An optional message providing additional information.</param>
        /// <returns>A <see cref="ServiceResponse"/> indicating success.</returns>
        public static ServiceResponse Success(HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null)
        {
            return new ServiceResponse(message, true, statusCode);
        }

        /// <summary>
        /// Creates a failed <see cref="ServiceResponse"/> with an optional message and status code.
        /// </summary>
        /// <param name="statusCode">The HTTP status code (default is <see cref="HttpStatusCode.InternalServerError"/>).</param>
        /// <param name="message">An optional message providing additional information.</param>
        /// <returns>A <see cref="ServiceResponse"/> indicating failure.</returns>
        public static ServiceResponse Failure(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string? message = null)
        {
            return new ServiceResponse(message, false, statusCode);
        }
    }

    /// <summary>
    /// Represents a generic response from a service, including a data payload, status, message, and HTTP status code.
    /// </summary>
    /// <typeparam name="T">The type of the data payload.</typeparam>
    public class ServiceResponse<T> : ServiceResponse
    {
        /// <summary>
        /// Gets or sets the data payload of the response.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse{T}"/> class.
        /// </summary>
        public ServiceResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="data">The data payload of the response.</param>
        /// <param name="message">A message providing additional information about the response.</param>
        /// <param name="succeeded">A value indicating whether the operation succeeded.</param>
        /// <param name="statusCode">The HTTP status code associated with the response.</param>
        public ServiceResponse(T data, string? message, bool succeeded, HttpStatusCode statusCode)
            : base(message, succeeded, statusCode)
        {
            Data = data;
        }

        /// <summary>
        /// Creates a successful <see cref="ServiceResponse{T}"/> with the specified data, an optional message, and status code.
        /// </summary>
        /// <param name="data">The data payload to include in the response.</param>
        /// <param name="statusCode">The HTTP status code (default is <see cref="HttpStatusCode.OK"/>).</param>
        /// <param name="message">An optional message providing additional information.</param>
        /// <returns>A <see cref="ServiceResponse{T}"/> indicating success.</returns>
        public static ServiceResponse<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null)
        {
            return new ServiceResponse<T>(data, message, true, statusCode);
        }

        /// <summary>
        /// Creates a failed <see cref="ServiceResponse{T}"/> with an optional message and status code, and no data.
        /// </summary>
        /// <param name="statusCode">The HTTP status code (default is <see cref="HttpStatusCode.InternalServerError"/>).</param>
        /// <param name="message">An optional message providing additional information.</param>
        /// <returns>A <see cref="ServiceResponse{T}"/> indicating failure.</returns>
        public static new ServiceResponse<T> Failure(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string? message = null)
        {
            return new ServiceResponse<T>(default!, message, false, statusCode);
        }
    }
}
