using Microsoft.AspNetCore.Identity;

namespace FullStack2._0.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public int PostalCode { get; set; }
    }

}
