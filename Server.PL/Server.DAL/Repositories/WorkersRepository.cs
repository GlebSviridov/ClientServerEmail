using System;
using System.Collections.Generic;
using Server.DAL.Interfaces;

namespace Server.DAL.Repositories
{
    public class WorkersRepository : IRepository<Workers>
    {
        private readonly MailSystemContext _context;

        public WorkersRepository(string connectionString)
        {
            _context = new MailSystemContext(connectionString);
        }

        public IEnumerable<Workers> GetAll()
        {
            return _context.Workers;
        }

        public Workers Get(int id)
        {
            return _context.Workers.Find(id);
        }

        public void Create(Workers item)
        {
            if (item == null)
            {
                throw new NullReferenceException();
            }
            _context.Workers.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Workers item = _context.Workers.Find(id);
            if (item != null)
            {
                _context.Workers.Remove(item);
            }
        }
    }
}