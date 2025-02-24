using Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPi.CustomsAttribute;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager = userManager;

        private readonly RoleManager<IdentityRole> roleManager = roleManager;

        [Authorize]
        [CustomAuthorize(nameof(Permissions.Read_User))]
        [HttpGet("Profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found");
            }

            //foreach (var value in Enum.GetValues(typeof(Models.Enums.Roles)))
            //{
            //    Console.WriteLine(value);
            //    var description = EnumHelper<Roles>.GetDisplayValue((Roles)value);
            //    Console.WriteLine(description);
            //}

            var userProfile = new Dto.UserProfile { Id = user.Id, Name = user.UserName!, Email = user.Email!, PhoneNumber = user.PhoneNumber! };

            //      userProfile.Permisos.Add()
            //var per = await userManager.GetClaimsAsync(user);

            //var perRol = new List<System.Security.Claims.Claim>();// roleManager.GetClaimsAsync(roleManager.Roles.First(x => x.Name == Roles.SystemAdmin.ToString())).Result.ToList();

            //userManager.GetRolesAsync(user).Result.ToList().ForEach(x =>
            //{
            //    perRol.AddRange(roleManager.GetClaimsAsync(roleManager.Roles.First(r => r.Name!.ToLower() == x.ToLower())).Result.ToList());
            //});

            //foreach (var item in perRol)
            //{
            //    userProfile.Permisos.Add(item.Value);
            //    //await userManager.AddClaimAsync(user, item);
            //}

            userManager.GetClaimsAsync(user).Result.ToList().ForEach(x =>
            {
                userProfile.Permissions.Add(x.Value);
            });

            return Ok(userProfile);
        }

        [HttpGet("Welcome")]
        [CustomAuthorize("Permissions.Read_User")]
        public IActionResult Welcome()
        {
            if (User.Identity == null || User.Identity.IsAuthenticated)
            {
                return Ok($"Welcome {User.Identity?.Name}");
            }
            else
            {
                return Unauthorized("You are NOT Authenticated");
            }
        }
    }
}