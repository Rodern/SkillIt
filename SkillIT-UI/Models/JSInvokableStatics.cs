using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using SkillIT_UI;
using SkillIT_UI.Authentication;
using Blazored.LocalStorage;
using BusinessLogic;

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

        [JSInvokable]
        public static void MarkAsAuthorized(string userToken)
        {
            //CustomAuthenticationStateProvider customAuthenticationStateProvider = new();
            //customAuthenticationStateProvider.MarkUserAsAuthenticated(userToken, new AuthenticationService(new()));
        }
    }
}
