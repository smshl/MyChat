using Microsoft.EntityFrameworkCore;
using MyChat.Domain.Repositories;
using MyChat.Infrastructure.Contexts;
using MyChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat.Infrastructure.Repositories
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override User GetById(string id)
        {
            return _context.Users.First(u => u.Id == id);
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

    }
}
