using System.Security.Claims;

namespace st10383430_PROG6212_POE.Models
{
    public class Lecturer
    {
        public int LecturerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Claim> Claims { get; set; }
    }
}
