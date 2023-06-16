using Microsoft.AspNetCore.Identity;

namespace Even_And_Odds_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public string Role { get; set; }


        public string Status { get; set; }
        /*[Ignored]
        public bool IsOnline => Convert.ToBoolean(Status);*/
    }
}
