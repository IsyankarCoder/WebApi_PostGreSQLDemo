using Microsoft.AspNetCore.Identity;

namespace WebApi_PostGreSQLDemo.Database
{
    public class User:IdentityUser
    {
        public string? Initials { get; set; }
    }
}
