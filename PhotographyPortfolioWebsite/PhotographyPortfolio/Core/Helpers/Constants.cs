using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public static class ApiConstants
    {
        public const string BaseUrl = "https://localhost:44398/api/";
        public const string Bearer = "";
        public class WebConstants
        {
            #region endpoints
            public const string getDashboard = "Dashboard/getDashboard?isAdmin=true";
            #endregion
        }
    }
}
