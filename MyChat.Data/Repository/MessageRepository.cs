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
    public class MessageRepository : IRepository<Message>, IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public DbSet<Message> Messages { get; set; }

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

        public Message Get(Message entity)
        {
            var message = _context.Messages.SingleOrDefault(m => m == entity);
            if (entity == null || message == null)
                return null;
            return message;
        }

        public IQueryable<Message> GetAll()
        {
            return _context.Messages.AsQueryable();
        }

        public List<Message> GetAllList()
        {
            return _context.Messages.ToList();
        }


        public Message GetById(string id)
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
