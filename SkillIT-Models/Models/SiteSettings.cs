using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
    public static class SiteSettings
    {
        public static string BaseUrl { get; set; } = "";
        public static string BaseUrl_Local_Secured { get; set; } = "https://localhost:7165";
        public static string BaseUrl_Local { get; set; } = "http://localhost:5165";
    }
}
