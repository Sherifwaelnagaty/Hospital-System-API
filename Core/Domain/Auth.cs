using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Auth:Base
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }

    }
}
