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
    public class MessageRepository : Repository<Message> , IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool AddMessage(Message message)
        {
            var result = _context.Messages.Add(message);
            if (result == null)
            {
                return false;
            }

            _context.SaveChanges();
            return true;
        }


        public override Message GetById(string id)
        {
            var message = _context.Messages.FirstOrDefault(m => m.Id == int.Parse(id));
            if (message == null)
                return null;
            return message;
        }

        public List<Message> GetLatestMessages(string recieverId, string contactId)
        {
            return _context.Messages.Where(m => (m.SenderId == contactId && m.RecieverId == recieverId ||
                    m.SenderId == recieverId && m.RecieverId == contactId) && m.Delleted == false).OrderBy(t => t.SendDateTime).ToList();
        }
    }
}
