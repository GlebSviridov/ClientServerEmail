using System;
using System.Collections.Generic;
using System.Linq;
using Server.BLL.DTO;
using Server.BLL.Infrastructure;
using Server.BLL.Interfaces;
using Server.DAL;
using Server.DAL.Interfaces;

namespace Server.BLL.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IRepository<Workers> _workersRepository;
        private readonly IRepository<Letter> _letterRepository;

        public MessagesService()
        {
            _workersRepository = ServiceModule.Workers;
            _letterRepository = ServiceModule.Letter;
        }

        public IEnumerable<LetterDTO> GetAllLetters()
        {
            var lettersAll = _letterRepository.GetAll();
            List<LetterDTO> listLetters = new List<LetterDTO>();
            if (lettersAll == null)
            {
                throw new NullReferenceException("There no letters in database");
            }
            foreach (var letter in lettersAll)
            {
                listLetters.Add(new LetterDTO(letter));
            }

            return listLetters;
        }

        public IEnumerable<LetterDTO> GetAllLettersForConcreteUser(int userId)
        {
            var lettersAll = _letterRepository.GetAll().Where(w => w.RecieverId == userId);
            List<LetterDTO> resultList = new List<LetterDTO>();
            if (lettersAll == null)
            {
                throw new NullReferenceException("There no letters in database");
            }
            foreach (var letter in lettersAll)
            {
                resultList.Add(new LetterDTO(letter));
            }

            return resultList;
        }

        public void AddLetter(LetterDTO letter)
        {
            if (letter == null)
            {
                throw new NullReferenceException();
            }
            _letterRepository.Create(new Letter(letter.Id, letter.LetterTheme, letter.SenderId, letter.RecieverId, letter.LetterDate, letter.Content));
        }

        public void RemoveLetter(int letterId)
        {
            _letterRepository.Delete(letterId);
        }

        public LetterDTO GetLetterById(int letterId)
        {
            var letter = _letterRepository.Get(letterId);
            LetterDTO resultLetter = new LetterDTO(letter);
            return resultLetter;
        }
    }
}