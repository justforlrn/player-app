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
                string extension = Path.GetExtension(ufile.FileName);

                // Never trust user's provided file name
                string fileName = $"{Guid.NewGuid().ToString() }{ extension }";

                // Combine the path with web root and my folder of choice, 
                // "uploads" 
                var path = Path.Combine(_env.WebRootPath, "uploads", "images").ToLower();

                // If the path doesn't exist, create it.
                // In your case, you might not need it if you're going 
                // to make sure your `keys.json` file is always there.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Combine the path with the file name
                string fullFileLocation = Path.Combine(path, fileName).ToLower();

                // If your case, you might just need to open your 
                // `keys.json` and append text on it.
                // Note that there is FileMode.Append too you might want to
                // take a look.
                using (var fileStream = new FileStream(fullFileLocation, FileMode.Create))
                {
                    await ufile.CopyToAsync(fileStream);
                }

                // I only want to get its relative path
                return fullFileLocation.Replace(_env.WebRootPath,
                    String.Empty, StringComparison.OrdinalIgnoreCase);
                //string imagePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");
                //bool exists = Directory.Exists(imagePath);
                //if (!exists)
                //    Directory.CreateDirectory(imagePath);
                //var fileName = Path.GetRandomFileName();
                //var fileExtension = Path.GetExtension(ufile.FileName);
                //var groupNameExtension = fileName + fileExtension;
                //var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", groupNameExtension);
                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    await ufile.CopyToAsync(fileStream);
                //}
                //var pathImage = _env.WebRootFileProvider.GetFileInfo("images/" + groupNameExtension)?.PhysicalPath;
                //return new
                //{
                //    imageUrl = $"images/{pathImage.Split("wwwroot\\images\\").Last()}"
                //};
            }
            throw new UserFriendlyException("Lỗi khi tải ảnh lên");
        }
    }
}
