using Microsoft.AspNetCore.Identity;

namespace DotnetIdentityApp.Models
{
    public class PetShopUser : IdentityUser
    {
    }
    public class ApplicationRole : IdentityRole
    {
    }
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
    }
}
