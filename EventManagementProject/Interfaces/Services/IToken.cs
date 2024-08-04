using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Services
{
    public interface IToken
    {
        public Task<string> GenerateJSONWebToken(User user);
    }
}
