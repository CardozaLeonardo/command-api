using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(ur => new {ur.UserId, ur.RoleId});
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Role> Role { get; set; }
        
        public DbSet<User> Users { get; set;}

        public DbSet<UserRole> UserRoles { get; set; }
    }
}