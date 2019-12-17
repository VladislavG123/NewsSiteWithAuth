using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteNews.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}