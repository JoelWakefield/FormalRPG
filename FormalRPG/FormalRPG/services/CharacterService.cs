using FormalRPG.Data;

namespace FormalRPG.services
{
    public interface ICharacterService
    {
        public List<Character> GetCharacters();
        public Character GetCharacter(int id);
        public void CreateUpdateCharacter(Character character);
        public void DeleteCharacter(int id);
    }

    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _context;

        public CharacterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Character> GetCharacters()
        {
            return _context.Characters.ToList();
        }

        public Character GetCharacter(int id)
        {
            return _context.Characters.FirstOrDefault(c => c.Id == id) ?? new Character();
        }

        public void CreateUpdateCharacter(Character character)
        {
            if (_context.Characters.Any(c => c.Id == character.Id))
            {
                _context.Characters.Update(character);
            }
            else
            {
                _context.Characters.Add(character);
            }

            _context.SaveChanges();
        }

        public void DeleteCharacter(int id)
        {
            var character = _context.Characters.FirstOrDefault(c => c.Id == id);

            if (character != null)
            {
                _context.Characters.Remove(character);
                _context.SaveChanges();
            }
        }
    }
}
