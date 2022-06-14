using kolokwium.Models.DTOs;
using System.Threading.Tasks;

namespace kolokwium.Services
{
    public interface IMusicianService
    {
        public Task<MusicianGet> GetMusician(int id);
        public Task DeleteMusician(int id);
    }
}
