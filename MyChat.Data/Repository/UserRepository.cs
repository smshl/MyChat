using Microsoft.EntityFrameworkCore;
using MyChat.Core.Models;
using MyChat.Core.RepositoryInterfaces;
using MyChat.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat.Infrastructure.Repository
{
    public class UserRepository : IRepository<User> , IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public DbSet<User> Users { get; }

        public User Get(User entity)
        {
            return _context.Users.SingleOrDefault(u => u == entity);
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users.AsQueryable();
        }

        public List<User> GetAllList()
        {
            return _context.Users.ToList();
        }

        public User GetById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if(user == null)
                return null;

            return user;
        }

    }
}
