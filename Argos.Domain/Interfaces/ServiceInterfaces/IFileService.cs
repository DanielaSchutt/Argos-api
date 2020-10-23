using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Argos.Domain.Interfaces.ServiceInterfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
        bool RemoveFile(string imageName);
        bool RemoveFile(string[] imagesName);
    }
}