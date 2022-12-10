using Microsoft.EntityFrameworkCore;
using MyChat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat.Core.Db
{
    public interface IDbContext
    {
        int SaveChanges();
        DbSet<Message> Messages { get; set; }
        DbSet<User> Users { get; set; }
    }
}
