using Microsoft.AspNetCore.Identity;



namespace E_Commerce.Doamin.Entities.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public string DisplayName { get; set; }

        public Address? Address { get; set; }
    }
}
