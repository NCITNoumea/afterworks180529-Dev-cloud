using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace MS.Afterworks.HappyFace.Repositories
{
    public interface ISmileRepository
    {
        Task<bool> AddSmileAsync(Smile smile);

        Task<int> CountSmileUp();

        Task<int> CountSmileDown();
    }
}
