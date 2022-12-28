using Microsoft.JSInterop;
using System;


namespace SkillIT_UI.Models
{
    public static class JSInvokableStatics
    {
        [JSInvokable]
        public static DateTime GetDateFromTokenTicks(long ticks)
        {
            return DateTimeOffset.FromUnixTimeSeconds(ticks).DateTime;
        }

        [JSInvokable]
        public static string SaveVisitor(string visitData, long trackId, string origin)
        {
            string filePath = "vistors_data/" + Convert.ToString(trackId) + ".json";
            if (!Directory.Exists("vistors_data"))
            {
                Directory.CreateDirectory("vistors_data");
            }
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, visitData);
            }
            return File.ReadAllText(filePath);
        }
    }
}
