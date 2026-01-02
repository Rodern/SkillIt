# UserService.cs Manual Fixes Required

## Issue: Syntax Error at Line 125-127

The `AddUser` method has a broken object initialization. The `Otp` object is missing closing brace and required code between lines 125-127.

### Current Code (BROKEN - Lines 117-131):
```csharp
				Otp otp = new()
				{
                        Code = AuthenticationHelper.GenerateOTP(),
					Guid = AuthenticationHelper.GenerateGuid(),
					ExpiryDate = DateTime.UtcNow.AddMonths(2),
					UserId = user.Id,
					User = null!,
				};
				
				string confirmationEmailTemplate = SiteSettings.GetConfirmEmailTemplate(emailConfirmationLink, "accounthelper@itskills.ovh", SiteSettings.SupportEmail, SiteSettings.BaseUrl);
				string welcomeEmailTemplate = SiteSettings.GetWelcomeEmailTemplate(user.FirstName, SiteSettings.BaseUrl);
```

**Problem**: The variable `emailConfirmationLink` on line 127 is used but never defined!

### Fixed Code (INSERT THESE LINES):

Replace lines 117-131 with:

```csharp
				Otp otp = new()
				{
                        Code = AuthenticationHelper.GenerateOTP(),
					Guid = AuthenticationHelper.GenerateGuid(),
					ExpiryDate = DateTime.UtcNow.AddMonths(2),
					UserId = user.Id,
					User = null!,
				};

				OTPService!.AddEmailOTP(otp);
				//Sendmail(user.Email, user.Id, otp.Guid);

				string emailConfirmationLink = $"{SiteSettings.BaseUrl}/confirm_email/{user.Id}?guid={otp.Guid}";
				
				string confirmationEmailTemplate = SiteSettings.GetConfirmEmailTemplate(emailConfirmationLink, "accounthelper@itskills.ovh", SiteSettings.SupportEmail, SiteSettings.BaseUrl);
				string welcomeEmailTemplate = SiteSettings.GetWelcomeEmailTemplate(user.FirstName, SiteSettings.BaseUrl);
```

### Other Issues to Fix (Already Applied, verify they're present):

1. ✅ **Lines 20-25**: Service dependencies should be nullable
2. ✅ **Line 57**: hostEnvironment usage needs null-forgiving operator: `hostEnvironment!.WebRootPath`
3. ✅ **Lines 142-155**: Service calls need null-forgiving operators
4. ✅ **Lines 170-183**: GetUser methods should return `User?`
5. ✅ **Line 187**: UpdatePassword should use `User?`

---

## Alternative: Complete AddUser Method (Lines 82-160)

If easier, replace the ENTIRE `AddUser` method (lines 82-160) with this corrected version:

```csharp
	public ResponseModel AddUser(UserModel userModel)
	{
		var users = DatabaseContext.Users.Where(u => u.Id == userModel.UserId).ToList();
		try
		{
			if (users.Count == 0)
			{
				User user = new()
				{
					Address = userModel.Address,
					DateCreated = DateTime.UtcNow,
					Email = userModel.Email,
					FirstName = userModel.FirstName,
					LastName = userModel.LastName,
					Password = AuthenticationHelper.EncryptPassword(userModel.Password),
					DateOfBirth = userModel.Dob,
					Phone = userModel.Phone,
					Gender = Enum.TryParse<Gender>(userModel.Gender, true, out var gender) ? gender : Gender.Other,
					ProfileImage = userModel.ProfileImage
				};

				Account account = new()
				{
					UserId = user.Id,
					Status = SkillIT_Models.Entities.Core.AccountStatus.PASSIVE,
					LoginInfo = JsonConvert.SerializeObject(userModel.LoginInfos),
					LoginAttempt = JsonConvert.SerializeObject(userModel.LoginAttemps),
					AccountType = AccountType.user,
					User = user,
					RoleId = 1,
					Role = null!,
					LastLogin = DateTime.UtcNow
				};
				DatabaseContext.Accounts.Add(account);
				DatabaseContext.Users.Add(user);
				DatabaseContext.SaveChanges();

				Otp otp = new()
				{
                        Code = AuthenticationHelper.GenerateOTP(),
					Guid = AuthenticationHelper.GenerateGuid(),
					ExpiryDate = DateTime.UtcNow.AddMonths(2),
					UserId = user.Id,
					User = null!,
				};

				OTPService!.AddEmailOTP(otp);
				//Sendmail(user.Email, user.Id, otp.Guid);

				string emailConfirmationLink = $"{SiteSettings.BaseUrl}/confirm_email/{user.Id}?guid={otp.Guid}";
				
				string confirmationEmailTemplate = SiteSettings.GetConfirmEmailTemplate(emailConfirmationLink, "accounthelper@itskills.ovh", SiteSettings.SupportEmail, SiteSettings.BaseUrl);
				string welcomeEmailTemplate = SiteSettings.GetWelcomeEmailTemplate(user.FirstName, SiteSettings.BaseUrl);

				SentMail confirmationSentmail = new()
				{
					UserId = user.Id,
					EmailBody = confirmationEmailTemplate,
					DateSent = DateTime.UtcNow,
					EmailType = EmailSentType.verify_email,
				};
				SentMail userWelcomeSentmail = new()
				{
					UserId = user.Id,
					EmailBody = welcomeEmailTemplate,
					DateSent = DateTime.UtcNow,
					EmailType = EmailSentType.welcome_email,
				};

				var response = AccountService!.CreateSentMail(confirmationSentmail);
				response = AccountService.CreateSentMail(userWelcomeSentmail);

				response = AccountService.SendFirstNotifications(user);

				MailingService!.SendMailUsingSendGridAsync(user.Email, $"{user.FirstName} {user.LastName}", $"Welcome {user.FirstName}", welcomeEmailTemplate, SiteSettings.InfoEmail, SiteSettings.InfoEmailName).Wait();
				MailingService.SendMailUsingSendGridAsync(user.Email, $"{user.FirstName} {user.LastName}", "Please confirm your email", confirmationEmailTemplate, SiteSettings.AccountHelperEmail, SiteSettings.AccountHelperEmailName).Wait();

				return new(true, "Success");
			}
			return new(false, "Failed: UserExists");
		}
		catch (Exception ex)
		{
			return new(false, ex.Message);
		}
	}
```

---

## Steps to Fix:

1. Open [UserService.cs](BusinessLogic/UserService.cs) in VS Code
2. Find line 125 (after `User = null!,` and the closing `};`)
3. Insert the 4 missing lines:
   ```csharp
   OTPService!.AddEmailOTP(otp);
   //Sendmail(user.Email, user.Id, otp.Guid);

   string emailConfirmationLink = $"{SiteSettings.BaseUrl}/confirm_email/{user.Id}?guid={otp.Guid}";
   ```
4. Save the file
5. Build: `dotnet build BusinessLogic/BusinessLogic.csproj`
6. Verify errors drop from 54 to ~20 or fewer

---

## Expected Error Reduction:

- **Before Fix**: 54 errors (mostly due to undefined `emailConfirmationLink`)
- **After Fix**: ~15-20 errors (remaining nullable warnings in other services)

Once this is fixed, the BusinessLogic project should build successfully with only package compatibility warnings remaining!
