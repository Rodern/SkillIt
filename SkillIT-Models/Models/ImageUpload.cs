using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
    public class ImageUpload
    {
        public IFormFile Images { get; set; }

        public static byte[] GetBytes(IFormFile image)
        {
            using var fileStream = image.OpenReadStream();
            byte[] bytes = new byte[image.Length];
            fileStream.Read(bytes, 0, (int)image.Length);
            return bytes;
        }
    }
}
