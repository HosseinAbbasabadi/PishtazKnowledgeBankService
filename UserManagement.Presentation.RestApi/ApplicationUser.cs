using Microsoft.AspNetCore.Identity;

namespace UserManagement.Presentation.RestApi
{
    public class ApplicationUser : IdentityUser
    {
        public long SubjectId { get; set; }
        public string FullName { get; set; }
    }
}
