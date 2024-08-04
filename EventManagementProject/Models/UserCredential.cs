using System.ComponentModel.DataAnnotations;

namespace EventManagementProject.Models
{
    public class UserCredential
    {
        [Key]
        public int UserCredentialId { get; set; }
        public int UserId { get; set; } // foreign key
        public byte[] HashedPassword { get; set; }
        public byte[] PasswordHashKey { get; set; }
        public string Role { get; set; }

        public User User { get; set; } // naviagation property
    }
}
