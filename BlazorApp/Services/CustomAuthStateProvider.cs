using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace BlazorApp.Services;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient httpClient;

    private readonly ISyncLocalStorageService localStorage;

    public CustomAuthStateProvider(HttpClient httpClient, ISyncLocalStorageService localStorage)
    {
        this.httpClient = httpClient;
        this.localStorage = localStorage;

        var accessToken = localStorage.GetItem<string>("accessToken");
        if (accessToken != null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        try
        {
            var response = await httpClient.GetAsync("api/Account/Profile");
            //var response = await httpClient.GetAsync("manage/info");
            if (response.IsSuccessStatusCode)
            {
                var strResponse = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonNode.Parse(strResponse);
                var email = jsonResponse!["email"]!.ToString();
                var permisos = jsonResponse!["permissions"]!.AsArray();

                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, email),
                    new(ClaimTypes.Email, email)
                };
                //JsonObject.Parse(permisos).ToList().ForEach(x => claims.Add(new(ClaimTypes.Role, x.ToString())));

                foreach (var item in permisos)
                {
                    claims.Add(new(ClaimTypes.Role, item.ToString()));
                }

                var identity = new ClaimsIdentity(claims, "Token");
                user = new ClaimsPrincipal(identity);
                //user.Claims.Append(new Claim("Permiso", "delete-user"));
                //user.Claims.Append(new Claim("Permiso", "delete-user"));

                //user.HasClaim(x => x.Type == "Permiso" && x.Value == "delete-user");

                return new AuthenticationState(user);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return new AuthenticationState(user);
    }

    public async Task<FormResult> LoginAsync(string email, string password)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("login", new { email, password });

            if (response.IsSuccessStatusCode)
            {
                var strResponse = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonNode.Parse(strResponse);
                var accessToken = jsonResponse?["accessToken"]?.ToString();
                var refreshToken = jsonResponse?["refreshToken"]?.ToString();

                localStorage.SetItem("accessToken", accessToken);
                localStorage.SetItem("refreshToken", refreshToken);

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // need to refresh auth state
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

                return new FormResult { Succeeded = true };
            }
            else
            {
                return new FormResult { Succeeded = false, Errors = ["Invalid email or password"] };
            }
        }
        catch
        {
        }

        return new FormResult { Succeeded = false, Errors = ["Connection Error"] };
    }

    public async Task<FormResult> RegisterAsync(Dto.Register register)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("register", register);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await LoginAsync(register.Email, register.Password);
                return loginResponse;
            }
            else
            {
                var strResponse = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonNode.Parse(strResponse);
                var errors = jsonResponse!["errors"]!.AsObject();
                //return new FormResult { Succeeded = false, Errors = [errors?[0]] };
                //return new FormResult { Succeeded = false, Errors = errors?.Select(x => x.ToString()).ToArray() ?? ["Bad_request"] };

                var errorList = new List<string>();
                foreach (var error in errors)
                {
                    errorList.Add(error!.Value![0]!.ToString());
                }
                return new FormResult { Succeeded = false, Errors = [.. errorList] };
            }
        }
        catch (Exception)
        {
            //throw;
            return new FormResult { Succeeded = false, Errors = ["Conntection Error"] };
        }
    }

    public void Logout()
    {
        localStorage.RemoveItem("accessToken");
        localStorage.RemoveItem("refreshToken");

        httpClient.DefaultRequestHeaders.Authorization = null;

        // need to refresh auth state
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}

public class FormResult
{
    public bool Succeeded { get; set; }

    public string[] Errors { get; set; } = [];
}