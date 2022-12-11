using Microsoft.EntityFrameworkCore;
using MyChat.Core.Models;
using MyChat.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat.Core.RepositoryInterfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        bool AddMessage(Message message);
        List<Message> GetLatestMessages(string recieverId, string contactId);
        DbSet<Message> Messages { get; set; }
    }
}
