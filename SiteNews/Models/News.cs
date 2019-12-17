using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteNews.Models
{
    public class News
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
        public string ImagePath { get; set; }

    }
}