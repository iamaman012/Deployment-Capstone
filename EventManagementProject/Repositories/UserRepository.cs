using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementProject.Repositories
{
    public class UserRepository : Repository<int,User>,IUserRepository
    {
        public UserRepository(EventManagementContext context) : base(context) { }

        public async Task<IEnumerable<C>> GetQuotationResponseByUserId<C>(int userId, string eventType) where C : class
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.PrivateQuotationRequests)
                        .ThenInclude(pqr => pqr.PrivateQuotationResponse)
                    .Include(u => u.PrivateQuotationRequests)
                        .ThenInclude(e => e.Event)
                    .Include(u => u.PublicQuotationRequests)
                        .ThenInclude(pqr => pqr.PublicQuotationResponse)
                    .Include(u => u.PublicQuotationRequests)
                        .ThenInclude(e => e.Event)
                    .FirstOrDefaultAsync(u => u.UserId == userId);

                if (user == null)
                {
                    return Enumerable.Empty<C>();
                }

                if (eventType == "Public")
                {
                    var publicQuotationResponses = user.PublicQuotationRequests
                        .Select(pqr => pqr.PublicQuotationResponse as C)
                        .Where(pqr => pqr != null)
                        .ToList();
                    return publicQuotationResponses;
                }
                else
                {
                    var privateQuotationResponses = user.PrivateQuotationRequests
                        .Select(pqr => pqr.PrivateQuotationResponse as C)
                        .Where(pqr => pqr != null)
                        .ToList();
                    return privateQuotationResponses;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<User> GetUserByEmail(string email)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserByEmailWithUserCredential(string email)
        {
            User? user = await _context.Users.Include(u => u.UserCredential).FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        //public async Task<User> Add(User entity)
        //{
        //    try
        //    {
        //        await _context.Users.AddAsync(entity);
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<User> Delete(User entity)
        //{
        //    try
        //    {
        //        _context.Users.Remove(entity);
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<IEnumerable<User>> GetAll()
        //{
        //    try
        //    {
        //        var users = await _context.Users.ToListAsync();
        //        return users;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public Task<User> GetById(int id)
        //{
        //    try
        //    {
        //        var user = _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        //        return user;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<User> Update(User entity)
        //{
        //    try
        //    {
        //        _context.Users.Update(entity);
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
