using System.Web.Helpers;

public static class AuthenticationHelpers
{
    public static string AuthenticationKey = "SkillIt Authencation";

    public static string EncryptPassword(string password)
    {
        return Crypto.HashPassword(password);
    }

    public static int GenerateOTP()
    {
        Random random= new();
        int randomNumber = random.Next(1000000);
        string sixDigits = randomNumber.ToString("D6");
        return int.Parse(sixDigits);
    }
}