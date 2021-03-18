using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Business.StringInfos
{
    public class JwtInfo
    {
        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string SecurityKey = "okanokanokanokan";
        public const double TokenExp = 30;
    }
}
