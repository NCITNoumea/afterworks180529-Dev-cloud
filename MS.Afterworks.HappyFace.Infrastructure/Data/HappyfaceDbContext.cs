using Microsoft.EntityFrameworkCore;
using MS.Afterworks.HappyFace.Core.Models;

namespace MS.Afterworks.HappyFace.Infrastructure.Data
{
    public class HappyfaceDbContext : DbContext
    {
        public HappyfaceDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Smile> Smiles { get; set; }
    }
}   