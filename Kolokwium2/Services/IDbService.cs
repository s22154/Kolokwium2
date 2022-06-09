using System.Threading.Tasks;
using Kolokwium2.Models;
using Kolokwium2.Models.DTOs;

namespace Kolokwium2.Services
{
    public interface IDbService
    {
        public Task<SomeKindOfMusician> GetMusician(int idMusician);
        public Task<bool> CheckMusicianExists(int idMusician);
        public Task<bool> CheckMusicianHasTracksNotOnAlbum(int idMusician);
        public Task<Musician> DeleteMusician(int idMusician);
    }
}