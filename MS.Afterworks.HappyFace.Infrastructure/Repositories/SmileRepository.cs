using System.Linq;
using System.Threading.Tasks;
using MS.Afterworks.HappyFace.Core.Models;
using MS.Afterworks.HappyFace.Infrastructure.Data;

namespace MS.Afterworks.HappyFace.Infrastructure.Repositories
{
    public class SmileRepository : ISmileRepository
    {
        private readonly HappyfaceDbContext _context;

        public SmileRepository(HappyfaceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddSmileAsync(Smile smile)
        {
            try
            {
                _context.Smiles.Add(smile);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> CountSmileDown()
        {
            try
            {
                return await Task.FromResult(_context.Smiles.Count(s => !s.IsHappy));
            }
            catch
            {
                return -1;
            }
        }

        public async Task<int> CountSmileUp()
        {
            try
            {
                return await Task.FromResult(_context.Smiles.Count(s => s.IsHappy));
            }
            catch
            {
                return -1;
            }
        }
    }
}
