using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Server.DAL.Interfaces;

namespace Server.DAL.Repositories
{
    public class LetterRepository : IRepository<Letter>
    {
        private readonly MailSystemContext _context;

        public LetterRepository(string connectionString)
        {
            _context = new MailSystemContext(connectionString);
        }

        public IEnumerable<Letter> GetAll()
        {
            return _context.Letter.Include(w => w.Sender).Include(w => w.Reciever);
        }

        public Letter Get(int id)
        {
            var lettersAll = _context.Letter.Include(w => w.Sender).Include(w => w.Reciever);
            var item = lettersAll.First(s => s.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }

            return item;
        }

        public void Create(Letter item)
        {
            if (item == null)
            {
                throw new NullReferenceException("You send a null letter");
            }
            _context.Letter.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Letter item = _context.Letter.Find(id);
            if (item != null)
            {
                _context.Letter.Remove(item);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Id was not found in DataBase");
            }
        }
    }
}