using Microsoft.EntityFrameworkCore;
using MyChat.Domain.Repositories;
using MyChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetUserByEmail(string email);
    }
}
