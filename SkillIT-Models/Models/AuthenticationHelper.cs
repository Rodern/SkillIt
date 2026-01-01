using System.Web.Helpers;
using SkillIT_Models.Constants;

/// <summary>
/// Provides authentication and security helper methods
/// </summary>
public static class AuthenticationHelper
{
    private static string _authenticationKey = "DEFAULT_KEY_REPLACE_IN_CONFIG";

    /// <summary>
    /// Gets the local storage key for user ID
    /// </summary>
    public static string LocalStorageUserIdKey => AppConstants.Authentication.LocalStorageUserIdKey;

    /// <summary>
    /// Gets or sets the authentication key (should be loaded from configuration)
    /// </summary>
    public static string AuthenticationKey 
    { 
        get => _authenticationKey;
        set => _authenticationKey = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// Gets the local storage key for authentication token
    /// </summary>
    public static string LocalStorageTokenKey => AppConstants.Authentication.LocalStorageTokenKey;

    /// <summary>
    /// Encrypts a password using a secure hashing algorithm
    /// </summary>
    /// <param name="password">The plain text password</param>
    /// <returns>The hashed password</returns>
    public static string EncryptPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or empty", nameof(password));
            
        return Crypto.HashPassword(password);
    }

    /// <summary>
    /// Generates a new GUID string
    /// </summary>
    /// <returns>A new GUID as a string</returns>
    public static string GenerateGuid()
    {
        return Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Generates a random 6-digit OTP
    /// </summary>
    /// <returns>A 6-digit OTP as an integer</returns>
    public static int GenerateOTP()
    {
        Random random = new();
        return random.Next(100000, 999999);
    }

    /// <summary>
    /// Verifies a password against a hashed password
    /// </summary>
    /// <param name="hashedPassword">The hashed password</param>
    /// <param name="password">The plain text password to verify</param>
    /// <returns>True if the password matches, otherwise false</returns>
    public static bool VerifyPassword(string hashedPassword, string password)
    {
        if (string.IsNullOrWhiteSpace(hashedPassword) || string.IsNullOrWhiteSpace(password))
            return false;
            
        return Crypto.VerifyHashedPassword(hashedPassword, password);
    }
}