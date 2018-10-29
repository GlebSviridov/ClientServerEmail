using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.BLL.DTO;
using Server.BLL.Interfaces;

namespace Server.AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMessagesService _messagesService;

        public ValuesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<LetterDTO> Get()
        {
            
            var letterList = _messagesService.GetAllLetters();
            return letterList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<LetterDTO> Get(int id)
        {
            return _messagesService.GetAllLettersForConcreteUser(id);
        }

        // POST api/values
        [HttpPost]
        public void Post(LetterDTO value)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }
            _messagesService.AddLetter(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _messagesService.RemoveLetter(id);
        }
    }
}
