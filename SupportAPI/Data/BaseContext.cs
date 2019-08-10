using System;
using Microsoft.EntityFrameworkCore;

namespace SupportAPI.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketUser> TicketUsers{ get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
