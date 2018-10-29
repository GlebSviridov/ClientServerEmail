using System;

namespace Client.Models
{
    public class LetterDTO
    {
        public LetterDTO()
        {

        }
        public LetterDTO(string letterTheme, int? senderId, int? recieverId, DateTime letterDate, string content)
        {
            
            LetterTheme = letterTheme;
            SenderId = senderId;
            RecieverId = recieverId;
            LetterDate = letterDate;
            Content = content;
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