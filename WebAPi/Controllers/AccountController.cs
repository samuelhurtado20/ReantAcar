using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize]
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

            return Ok(new Dto.UserProfile { Id = user.Id, Name = user.UserName!, Email = user.Email!, PhoneNumber = user.PhoneNumber! });
        }

        [HttpGet("Welcome")]
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