using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
    public class FileObjectInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        [MaxLength(1)]
        public string Type { get; set; }
        public long Size { get; set; } = 0;
    }
}
