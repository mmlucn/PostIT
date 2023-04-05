using Microsoft.EntityFrameworkCore;
using PostIT_Lib.Models;

namespace PostIT_API.EF
{
    public class PostITContext : DbContext
    {
        public PostITContext(DbContextOptions<PostITContext> options) : base(options)
        {
            
        }

        //public DbSet<PostItNote> PostItNote { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False");
        }
    }
}
