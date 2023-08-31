using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlarforms();

        Platform? GetPlatformById(int id);

        void CreatePlatform(Platform platform);
    }
}
