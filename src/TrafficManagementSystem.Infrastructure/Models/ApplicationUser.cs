using Microsoft.AspNetCore.Identity;

namespace TrafficManagementSystem.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    //public class Temp
    //{
    //    public void ffdj()
    //    {

    //    ApplicationUser applicationUser = new ApplicationUser();
    //      var id =  applicationUser.Id;
    //    }
    //}
}
