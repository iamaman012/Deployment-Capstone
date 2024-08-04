using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IUserRepository : IRepository<int,User>
    {
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserByEmailWithUserCredential(string email);

        
        public Task<IEnumerable<C>> GetQuotationResponseByUserId<C>(int userId, string eventType) where C : class;
       

    }
}
