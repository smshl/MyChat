using Microsoft.EntityFrameworkCore;
using MyChat.Core.Models;
using MyChat.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat.Core.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
        DbSet<User> Users { get; }
    }
}
