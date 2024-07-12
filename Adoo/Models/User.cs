using Microsoft.AspNetCore.Identity;

namespace Adoo.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }

    public static class UserRoles
    {
        /// <summary>
        /// The role name for the administrator.
        /// </summary>
        public const string Admin = "Admin";

        /// <summary>
        /// The role name for regular users.
        /// </summary>
        public const string User = "User";
    }

}