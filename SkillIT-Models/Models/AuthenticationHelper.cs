using System.Web.Helpers;

public static class AuthenticationHelper
{
    public static string LocalStorageUserIdKey { get; private set; } = "skillit_userId";

    public static string AuthenticationKey { get; private set; } = "SkillIt Authencation";

    public static string LocalStorageTokenKey { get; private set; } = "skillit_user-token";

    public static string EncryptPassword(string password)
    {
        return Crypto.HashPassword(password);
    }

	public static string GenerateGuid()
	{
        return Convert.ToString(Guid.NewGuid());
	}

	public static int GenerateOTP()
    {
        Random random= new();
        int randomNumber = random.Next(1000000);
        string sixDigits = randomNumber.ToString("D6");
        return int.Parse(sixDigits);
    }
}