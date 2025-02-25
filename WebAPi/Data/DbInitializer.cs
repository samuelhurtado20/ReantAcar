using Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using Models.Enums;
using System.Security.Claims;

namespace WebAPi.Data;

public class DbInitializer(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder modelBuilder = modelBuilder;

    private readonly string systemAdminRoleId = "00000000-0000-0000-0000-00000000000" + (int)Roles.SystemAdmin;

    public void Seed()
    {
        SeedRoles();
        SeedUser();
        SeedPermissions();
    }

    private void SeedRoles()
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = systemAdminRoleId, Name = Roles.SystemAdmin.ToString(), NormalizedName = Roles.SystemAdmin.GetDisplayName() },
            new IdentityRole() { Id = "00000000-0000-0000-0000-00000000000" + (int)Roles.Admin, Name = Roles.Admin.ToString(), NormalizedName = Roles.Admin.GetDisplayName() },
            new IdentityRole() { Id = "00000000-0000-0000-0000-00000000000" + (int)Roles.Seller, Name = Roles.Seller.ToString(), NormalizedName = Roles.Seller.GetDisplayName() },
            new IdentityRole() { Id = "00000000-0000-0000-0000-00000000000" + (int)Roles.Customer, Name = Roles.Customer.ToString(), NormalizedName = Roles.Customer.GetDisplayName() }
        );
    }

    private void SeedUser()
    {
        var systemAdmin = new IdentityUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = Roles.SystemAdmin.ToString(),
            NormalizedUserName = Roles.SystemAdmin.GetDisplayName(),
            Email = Roles.SystemAdmin.ToString().ToLower() + "@gmail.com",
            NormalizedEmail = Roles.SystemAdmin.ToString().ToLower() + "@gmail.com",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Admin@123"),
            SecurityStamp = string.Empty,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            AccessFailedCount = 0
        };

        modelBuilder.Entity<IdentityUser>().HasData(
            systemAdmin
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { UserId = systemAdmin.Id, RoleId = systemAdminRoleId }
        );
    }

    private void SeedPermissions()
    {
        List<IdentityRoleClaim<string>> permissions = new();
        foreach (var value in Enum.GetValues(typeof(Permissions)))
        {
            var permission = new IdentityRoleClaim<string>()
            {
                Id = permissions.Count + 1,
                RoleId = systemAdminRoleId,
                ClaimType = ClaimTypes.Role,
                ClaimValue = value.ToString()
            };
            permissions.Add(permission);
        }

        modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(
            permissions
        );
    }
}