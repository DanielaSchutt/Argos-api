using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.BaseRoot;using Argos.Domain.BaseRoot;

namespace Argos.Service
{
    public class FileService : IFileService
    {
        private readonly string FilesPath = "";

        public FileService()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directoryPath = Path.GetDirectoryName(location);
            this.FilesPath = directoryPath + Environment.GetEnvironmentVariable(Constants.FILES_PATH);
        }
        
        public async Task<string> SaveFileAsync(IFormFile file)
        {
            if(!Directory.Exists(this.FilesPath))
                Directory.CreateDirectory(this.FilesPath);

            Guid g = Guid.NewGuid();
            var extensao = Path.GetExtension(file.FileName);
            var fileName = g + extensao;

            if (!System.IO.File.Exists(this.FilesPath + fileName))
                using (var stream = new FileStream(this.FilesPath + fileName, FileMode.Create))
                    await file.CopyToAsync(stream);

            return fileName;
        }
        
        public bool RemoveFile(string imageName)
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directoryPath = Path.GetDirectoryName(location);

            if(!System.IO.File.Exists(this.FilesPath + imageName)) 
                return false;
            
            System.IO.File.Delete(this.FilesPath + imageName);

            return true;
        }

        public bool RemoveFile(string[] imagesName)
        {
            foreach(var imageName in imagesName) 
                if(!RemoveFile(imageName))
                    return false;

            return true;
        }
    }
}