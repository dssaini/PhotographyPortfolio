using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public static class Converters
    {
        public static int GetResponseCode(this ApiResponseCode resCode)
        {
            return (int)resCode;
        }
    }
}
