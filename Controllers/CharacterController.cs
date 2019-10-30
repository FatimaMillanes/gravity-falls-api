using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gravity_falls_api.Modules;
using gravity_falls_api.Dependencies;
using Microsoft.AspNetCore.Cors;
using System.Data.SqlClient;

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

         string connectionString = @"data source=DESKTOP-BBQP2VL; initial catalog=db_gravityfalls; user id=gravityfalls; password=1234";
        
        [HttpGet("{id}")]
        public Character GetCharacter(int id)
        {
            return listOfCharacters[id];
        }

        [HttpGet]
        public List<Character> GetCharacterList()
        {
            List<Character> characters = new List<Character>();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from tbl_characters", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Character character = new Character
                {/*for database*/
                    Id = reader.GetInt64(reader.GetOrdinal("id")),
                    FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                    SecondName = reader.GetString(reader.GetOrdinal("secondName")),
                    LastName = reader.GetString(reader.GetOrdinal("lastName")),
                    Description = reader.GetString(reader.GetOrdinal("descp")),
                    Age=reader.GetInt32(reader.GetOrdinal("age")) 
                    
                };
                characters.Add(character);
            }
            conn.Close();
            return characters;
        }
    }
}