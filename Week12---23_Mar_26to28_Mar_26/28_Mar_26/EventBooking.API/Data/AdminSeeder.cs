using Microsoft.AspNetCore.Identity;

namespace EventBooking.API.Data
{
    public static class AdminSeeder
    {
        public static async Task SeedAsync(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Create roles if they don't exist
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

            // Create admin user if doesn't exist
            var adminEmail = "admin@eventhub.com";
            var adminUser  = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var newAdmin = new IdentityUser
                {
                    UserName       = adminEmail,
                    Email          = adminEmail,
                    EmailConfirmed = true
                };

                // UserManager handles hashing internally — you just pass plain text
                var result = await userManager.CreateAsync(newAdmin, "Admin@123");

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }
    }
}