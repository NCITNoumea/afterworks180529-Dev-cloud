using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using MS.Afterworks.HappyFace.Core.Models;

namespace MS.Afterworks.HappyFace.Core.Infrastructure.Repositories
{
    public class SmileRepository : ISmileRepository
    {
        readonly HappyfaceDbContext _context;

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
                return await Task.FromResult<int>(_context.Smiles.Where(s => !s.IsHappy).Count());
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
                return await Task.FromResult<int>(_context.Smiles.Where(s => s.IsHappy).Count());
            }
            catch
            {
                return -1;
            }
        }
    }
}
