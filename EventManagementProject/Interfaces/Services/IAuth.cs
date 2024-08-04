using EventManagementProject.DTOs.UserDTO;

namespace EventManagementProject.Interfaces.Services
{
   
    
        public interface IAuth
        {
            public Task RegisterUser(RegisterDTO registerDto);
            public Task<LoginResponseDTO> Login(LoginDTO loginDto);
        
    }
}
