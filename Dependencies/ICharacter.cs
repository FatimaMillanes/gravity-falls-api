using System.Collections.Generic;
using gravity_falls_api.Modules;
namespace gravity_falls_api.Dependencies
{
    public interface ICharacter
    {
        List<Character> GetCharacterList();

        Character GetCharacter(int id);
    }
}