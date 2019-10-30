using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gravity_falls_api.Modules;
using gravity_falls_api.Dependencies;
using Microsoft.AspNetCore.Cors;

namespace gravity_falls_api.Controllers
{
    [Route("gravityfalls/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CharacterController : ICharacter
    {
        List<Character> listOfCharacters => new List<Character>
        {
            new Character
            {
                FirstName = "Mabel",
                SecondName = "",
                LastName = "Pines",
                Age = 13
            },
            new Character
            {
                FirstName = "Dipper ",
                SecondName = "",
                LastName = "Pines",
                Age = 13
            },
            new Character
            {
                FirstName = "Stanley ",
                SecondName = "",
                LastName = "Pines",
                Age = 60
            },
            new Character
            {
                FirstName = "Wendy",
                SecondName = "",
                LastName = "Corduroy",
                Age = 15
            },

            
        };
        [HttpGet("{id}")]
        public Character GetCharacter(int id)
        {
            return listOfCharacters[id];
        }

        [HttpGet]
        public List<Character> GetCharacterList()
        {
            return listOfCharacters;
        }
    }
}