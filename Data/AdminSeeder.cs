using Microsoft.AspNetCore.Identity;

namespace FullStack2._0.Data
{
    public static class AdminSeeder
    {
        public static async Task SeedAdmin(IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            IConfiguration config = serviceProvider.GetRequiredService<IConfiguration>();

            string email = config["AdminSettings:Email"]!;
            string password = config["AdminSettings:Password"]!;
            string firstName = config["AdminSettings:FirstName"]!;
            string surName = config["AdminSettings:SurName"]!;
            int postalCode = int.Parse(config["AdminSettings:PostalCode"]!);
            string city = config["AdminSettings:City"]!;
            string streetName = config["AdminSettings:StreetName"]!;

            ApplicationUser? user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                ApplicationUser admin = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    SurName = surName,
                    PostalCode = postalCode,
                    City = city,
                    StreetName = streetName
                };

                IdentityResult result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Roles.Admin);
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }               
            }
        }
    }
}