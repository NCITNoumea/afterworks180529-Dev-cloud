using System.Threading.Tasks;
using MS.Afterworks.HappyFace.Core.Models;

namespace MS.Afterworks.HappyFace.Core.Infrastructure.Repositories
{
    public interface ISmileRepository
    {
        Task<bool> AddSmileAsync(Smile smile);

        Task<int> CountSmileUp();

        Task<int> CountSmileDown();
    }
}
