using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SkillIT_Models.Models;
using BusinessLogic.Interfaces;
using System.Security.Claims;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SkillIT_Models.CRUD;
using SkillIT_Models.DatabaseModels;

namespace SkillIT_UI.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService LocalStorageService;
        private readonly IAuthenticationService AuthenticationService;
        private readonly IUserService UserService;
        private readonly IAccountService AccountService;
        private readonly IEntityService EntityService;
        private readonly IJSRuntime JSRuntime;

        //public CustomAuthenticationStateProvider()
        //{
        //}

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, IAuthenticationService authenticationService, IJSRuntime jSRuntime, IUserService userService, IAccountService accountService, IEntityService entityService)
        {
            LocalStorageService = localStorageService;
            AuthenticationService = authenticationService;
            JSRuntime = jSRuntime;
			UserService = userService;
			AccountService = accountService;
			EntityService = entityService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			return (new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
			//string userToken_encrypted = await LocalStorageService.GetItemAsync<string>(AuthenticationHelper.LocalStorageTokenKey);
   //         string userToken = string.Empty;
   //         if (userToken_encrypted != null && userToken_encrypted != string.Empty)
   //         {
   //             userToken = await JSRuntime.InvokeAsync<string>("decodeTextThis", userToken_encrypted);// Encoding.Default.GetString(bytes);
   //         }
   //         if (AuthenticationService._isEmptyOrInvalid(userToken).Success == false || userToken == null || userToken == "" || userToken == string.Empty)
   //         {
   //             return (new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
   //         }
			//string userEmail = await JSRuntime.InvokeAsync<string>("getEmailFromToken", userToken);
			
			//var user = UserService.GetUser(userEmail);
			//var account = AccountService.GetUserAccount(user.UserId);
			//var role = AccountService.GetAccountRole(account.RoleId);
			//JSRuntime.InvokeVoidAsync("alert", userEmail);

			//var identity = new ClaimsIdentity(new[]
   //         {
   //             new Claim("Token", userToken),
			//	new Claim("UserId", $"{user.UserId}"),
			//	new Claim("AccountId", $"{account.AccountId}"),
			//	new Claim(ClaimTypes.Email, user.Email),
			//	new Claim(ClaimTypes.Role, role.Name)
   //         }, "apiauth_type");

   //         var currentUser = new ClaimsPrincipal(identity);
   //         return await Task.FromResult(new AuthenticationState(currentUser));
        }

        public async void MarkUserAsAuthenticated(string userToken)
        {
            if (AuthenticationService._isEmptyOrInvalid(userToken).Success == false || userToken == null || userToken == "" || userToken == string.Empty)
            {
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
                return;
            }
			string userEmail = await JSRuntime.InvokeAsync<string>("getEmailFromToken", userToken);

			var user = UserService.GetUser(userEmail);
			var account = AccountService.GetUserAccount(user.Id);
			var role = AccountService.GetAccountRole(account.RoleId);
			//JSRuntime.InvokeVoidAsync("alert", userEmail);

			var identity = new ClaimsIdentity(new[]
			{
				new Claim("Token", userToken),
				new Claim("UserId", $"{user.Id}"),
				new Claim("AccountId", $"{account.Id}"),
				new Claim("Email", user.Email),
				new Claim("Role", role.Name)
			}, "apiauth_type");

			var currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(currentUser)));
        }

		public async void Authenticate()
		{

			try
			{
				JSRuntime.InvokeVoidAsync("initiateUser");

				string Token = await JSRuntime.InvokeAsync<string>("getUserToken");
				//await JSRuntime.InvokeVoidAsync("alert", Token);
				long UserId = long.Parse(await JSRuntime.InvokeAsync<string>("getUserId"));

				var response = AuthenticationService._isEmptyOrInvalid(Token);
				if (response.Success)
				{
					var user1 = UserService.GetUser(UserId);
					var account = AccountService.GetUserAccount(UserId);
					JSRuntime.InvokeVoidAsync("setUser", user1);
					JSRuntime.InvokeVoidAsync("setAccount", account);

					MarkUserAsAuthenticated(Token);

					JSRuntime.InvokeVoidAsync("chAuth");
					JSRuntime.InvokeVoidAsync("setEventHandlers");
					JSRuntime.InvokeVoidAsync("stickyHeader");

					return;
				}

				var user = UserService.GetUser(UserId);
				string userPassKey = await JSRuntime.InvokeAsync<string>("getUserPassKey");

				var authenticationResponse = AuthenticationService.Authenticate(new(user.Email, userPassKey, false, ""));
				if (authenticationResponse.Success)
				{
					var account = AccountService.GetUserAccount(UserId);
					JSRuntime.InvokeVoidAsync("setUser", user);
					JSRuntime.InvokeVoidAsync("setAccount", account);

					var AuthModel = JsonConvert.DeserializeObject<AuthenticatedModel>(authenticationResponse.Message);

					MarkUserAsAuthenticated(AuthModel.Token);

					JSRuntime.InvokeVoidAsync("chAuth");
					JSRuntime.InvokeVoidAsync("setEventHandlers");
					JSRuntime.InvokeVoidAsync("stickyHeader");

					return;
				}
			}
			catch (Exception)
			{
				
			}
		}

		public void MarkUserAsAuthenticated(string userToken, IAuthenticationService authenticationService)
		{
			if (authenticationService._isEmptyOrInvalid(userToken).Success == false || userToken == null || userToken == "" || userToken == string.Empty)
			{
				NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
				return;
			}
            
			var identity = new ClaimsIdentity(new[]
			{
				new Claim("Token", userToken),
			}, "apiauth_type");
			var user = new ClaimsPrincipal(identity);
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
		}

		public void MarkUserAsNotAuthenticated()
        {
            _ = LocalStorageService.RemoveItemAsync(AuthenticationHelper.LocalStorageTokenKey);
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
			JSRuntime.InvokeVoidAsync("logout");
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsNotAuthenticated(ILocalStorageService localStorageService)
        {
            _ = localStorageService.RemoveItemAsync(AuthenticationHelper.LocalStorageTokenKey);
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
