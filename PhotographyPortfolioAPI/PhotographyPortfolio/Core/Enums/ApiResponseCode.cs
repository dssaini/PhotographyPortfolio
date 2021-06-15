using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Enums
{
    public enum ApiResponseCode
    {
        OK = 200,
        BadRequest = 400,
        NotFound = 404,
        UnprocessableEntity = 422,
        InternalServerError = 500,
        AllReadyExist = 409,
    }
}
