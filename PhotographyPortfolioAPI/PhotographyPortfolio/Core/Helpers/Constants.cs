using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public static class ResponseMessages
    {
        /// <summary>
        /// Status Code 200 
        /// </summary>
        public const string Success = "Success";
        /// <summary>
        /// Status Code 404
        /// </summary>
        public const string NoRecordFound = "No Record Found";
        /// <summary>
        /// Status Code 500
        /// </summary>
        public const string ServerError = "Internal Server Error";
        /// <summary>
        /// Status Code 400
        /// </summary>
        public const string BadRequest = "Bad Request";
        /// <summary>
        /// Status Code 422 
        /// </summary>
        public const string UnprocessableEntity = "Unprocessable Entity";
        /// <summary>
        /// For image errors
        /// </summary>
        public const string UnprocessableImage = "Cannot Process Base 64 Image";
    }
}
