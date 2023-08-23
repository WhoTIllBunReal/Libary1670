using Microsoft.AspNetCore.Identity;

namespace Libary1670.Models
{
    public class ApplicationRole: IdentityRole
    {
        public string? Description { get; set; }
    }
}
