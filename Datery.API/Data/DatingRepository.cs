using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datery.API.Helpers;
using Datery.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Datery.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private ApplicationDbContext _context;

        public DatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetMainPhoto(int userId)
        {
            var photo = await _context.Photos.Where(p => p.UserId == userId && p.IsMain == true).FirstOrDefaultAsync();
            return photo;
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.Where(p => p.Id == id).FirstOrDefaultAsync();
            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        //public async Task<IEnumerable<User>> GetUsers()
        //{
        //    var users = await _context.Users.Include(p => p.Photos).ToListAsync();
        //    return users;
        //}

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.Include(p => p.Photos);

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
