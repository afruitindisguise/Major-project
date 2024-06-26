using Microsoft.EntityFrameworkCore;
using Major_Project.models;
using Microsoft.AspNetCore.Identity;


namespace Major_Project.repositories
{
    public class PlayerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Item> Items { get; set; }
       public DbSet<Data> Datas { get; set; }
        public PlayerDbContext(IConfiguration configuration){
            this._configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            optionsBuilder.EnableDetailedErrors();
        }
    }
}