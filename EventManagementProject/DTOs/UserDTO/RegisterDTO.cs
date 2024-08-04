namespace EventManagementProject.DTOs.UserDTO
{
    public class RegisterDTO : LoginDTO
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public string Role { get; set; }
    }
}
