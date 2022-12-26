using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace WebActiveHealthyKidsVietNam.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/file")]
    public class FileController : WebActiveHealthyKidsVietNamController
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("uploadimage")]
        public async Task<object> UploadFile(IFormFile ufile)
        {
            if (ufile != null && ufile.Length > 0)
            {
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");
                bool exists = Directory.Exists(imagePath);
                if (!exists)
                    Directory.CreateDirectory(imagePath);
                var fileName = Path.GetRandomFileName();
                var fileExtension = Path.GetExtension(ufile.FileName);
                var groupNameExtension = fileName + fileExtension;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", groupNameExtension);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ufile.CopyToAsync(fileStream);
                }
                var pathImage = _env.WebRootFileProvider.GetFileInfo("images/" + groupNameExtension)?.PhysicalPath;
                return new
                {
                    imageUrl = $"images/{pathImage.Split("wwwroot\\images\\").Last()}"
                };
            }
            throw new UserFriendlyException("Lỗi khi tải ảnh lên");
        }
    }
}
