namespace SiteNews.DataContext
{
    using SiteNews.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewsContext : DbContext
    {
        public NewsContext()
            : base("name=NewsContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
    }
}