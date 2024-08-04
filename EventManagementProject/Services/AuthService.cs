using EventManagementProject.DTOs.UserDTO;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;
using System.Security.Cryptography;
using System.Text;

namespace EventManagementProject.Services
{
    public class AuthService : IAuth
    {
        private readonly IUserRepository _userRepository;
        private readonly IToken _tokenService;
        public AuthService(IUserRepository userRepository, IToken tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<LoginResponseDTO> Login(LoginDTO loginDTO)
        {
            User storedUser = await _userRepository.GetUserByEmailWithUserCredential(loginDTO.Email);
            if (storedUser == null)
            {
                throw new InvalidEmailOrPasswordException();
            }
            HMACSHA512 hMACSHA = new HMACSHA512(storedUser.UserCredential.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            bool isPasswordSame = ComparePassword(encrypterPass, storedUser.UserCredential.HashedPassword);
            if (isPasswordSame)
            {
                LoginResponseDTO loginReturnDTO = new LoginResponseDTO();
                loginReturnDTO.UserId = storedUser.UserId;
                loginReturnDTO.Token = await _tokenService.GenerateJSONWebToken(storedUser);
                loginReturnDTO.Email=storedUser.Email;
                loginReturnDTO.FullName = storedUser.FullName;
                loginReturnDTO.Role=storedUser.UserCredential.Role;
                return loginReturnDTO;
            }
            throw new InvalidEmailOrPasswordException();
        }
        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task RegisterUser(RegisterDTO registerDto)
        {
            try
            {
                User existingUser = await _userRepository.GetUserByEmail(registerDto.Email);
                if (existingUser != null)
                {
                    throw new EmailAlreadyExistException("Email already exists");
                }
                User user = MapRegisterDTOWithUser(registerDto);
                await _userRepository.Add(user);
            }
            catch (EmailAlreadyExistException eafe)
            {
                throw new EmailAlreadyExistException(eafe.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private User MapRegisterDTOWithUser(RegisterDTO registerDTO)
        {
            User user = new User();
            user.Email = registerDTO.Email;
            user.FullName = registerDTO.FullName;
            user.PhoneNumber = registerDTO.PhoneNumber;
            user.UserCredential = CreateUserCredential(registerDTO.Password, registerDTO.Role);
            return user;
        }
        private UserCredential CreateUserCredential(string plainPassword, string role)
        {
            UserCredential credential = new UserCredential();
            HMACSHA512 hMACSHA = new HMACSHA512();
            


            credential.PasswordHashKey = hMACSHA.Key;
            credential.HashedPassword = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
            credential.Role = role;


            return credential;
        }
    }
}
