using System.Net;

namespace LKenselaar.CloudDatabases.CustomExceptions
{
    public class CustomException : Exception
    {
        /// <summary>
        /// Initializes an instance of the custom exception
        /// </summary>
        /// <param name="key"></param>
        /// <param name="description"></param>
        public CustomException(string key, string description) : base($"{key}:{description}")
        {
            Key = key;
            Description = description;
            StatusCode = HttpStatusCode.BadRequest;
        }

        public CustomException(string key, string description, HttpStatusCode statusCode) : base($"{key}:{description}")
        {
            Key = key;
            Description = description;
            StatusCode = statusCode;
        }

        /// <summary>
        /// The key of the domain exception. Typically the Error code
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// The description of the domain exception
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The http statuscode of the domain exception
        /// </summary>
        public HttpStatusCode StatusCode { get; }
    }
}
