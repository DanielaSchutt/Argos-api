/*using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.Interfaces.ServiceInterfaces;


namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMidiaService MidiaService;
        private readonly IFileService fileService;

        public FileController(IMidiaService MidiaService, IFileService fileService)
        {
            this.MidiaService = MidiaService;
            this.fileService = fileService;
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public async Task<IActionResult> UploadFilesAsync(List<IFormFile> files)
        {
            List<string> filesName = new List<string>();
            List<long> midiaIds = new List<long>();

            foreach(var item in files)
            {
                var path = await this.fileService.SaveFileAsync(item);

                filesName.Add(path);

                var midia = new Midia();
                midia.Caminho = path;
                midia.Nome = item.FileName;

                await this.MidiaService.AddAsync(midia);

                midiaIds.Add(midia.Id);
            }

            return Ok(new {
                status = HttpContext.Response.StatusCode,
                message = "Upload concluído",
                filesName = filesName,
                midiaIds = midiaIds,
            });
        }
    }
}
*/