using System;
using System.Collections.Generic;

namespace Server.DAL
{
    public partial class Workers
    {
        public Workers()
        {
            LetterReciever = new HashSet<Letter>();
            LetterSender = new HashSet<Letter>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Letter> LetterReciever { get; set; }
        public ICollection<Letter> LetterSender { get; set; }
    }
}
