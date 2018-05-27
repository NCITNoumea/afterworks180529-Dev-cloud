using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;

namespace MS.Afterworks.HappyFace.Repositories
{
    public class SmileRepositoryImpl : ISmileRepository
    {
        readonly HappyfaceDbContext _context;

        public SmileRepositoryImpl(HappyfaceDbContext context)
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
                return _context.Smiles.Where(s => !s.IsHappy).Count();
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
                return _context.Smiles.Where(s => s.IsHappy).Count();
            }
            catch
            {
                return -1;
            }
        }
    }
}
