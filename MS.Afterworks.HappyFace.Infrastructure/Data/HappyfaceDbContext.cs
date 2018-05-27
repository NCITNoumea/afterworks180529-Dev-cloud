using Microsoft.EntityFrameworkCore;
using MS.Afterworks.HappyFace.Core.Models;

namespace WebApplication.Data
{
    public class HappyfaceDbContext : DbContext
    {
        public HappyfaceDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Smile> Smiles { get; set; }
    }
}
