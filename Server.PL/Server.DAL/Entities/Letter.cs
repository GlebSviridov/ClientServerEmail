using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Server.DAL
{
    public partial class Letter
    {
        public Letter()
        {
            
        }
        public Letter(int id, string letterTheme, int? senderId, int? recieverId, DateTime letterDate, string content)
        {
            Id = id;
            LetterTheme = letterTheme;
            SenderId = senderId;
            RecieverId = recieverId;
            LetterDate = letterDate;
            Content = content;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
