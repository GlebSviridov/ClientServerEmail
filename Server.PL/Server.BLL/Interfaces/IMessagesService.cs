using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Server.BLL.DTO;
using Server.DAL;

namespace Server.BLL.Interfaces
{
    public interface IMessagesService
    {
        IEnumerable<LetterDTO> GetAllLetters();
        void AddLetter(LetterDTO letter);
        void RemoveLetter(int letterId);
        LetterDTO GetLetterById(int letterId);
        IEnumerable<LetterDTO> GetAllLettersForConcreteUser(int userId);

    }
}