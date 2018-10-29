using System;
using Server.DAL;

namespace Server.BLL.DTO
{
    public class LetterDTO
    {
        public LetterDTO()
        {
            
        }
        public LetterDTO(Letter letter)
        {
            Id = letter.Id;
            LetterTheme = letter.LetterTheme;
            SenderId = letter.SenderId;
            RecieverId = letter.RecieverId;
            LetterDate = letter.LetterDate;
            Content = letter.Content;
            Reciever = letter.Reciever;
            Sender = letter.Sender;
        }
        public int Id { get; set; }
        public string LetterTheme { get; set; }
        public int? SenderId { get; set; }
        public int? RecieverId { get; set; }
        public DateTime LetterDate { get; set; }
        public string Content { get; set; }

        public Workers Reciever { get; set; }
        public Workers Sender { get; set; }
    }
}