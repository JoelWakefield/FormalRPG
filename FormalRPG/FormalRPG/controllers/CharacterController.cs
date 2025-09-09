using FormalRPG.Data;
using FormalRPG.services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormalRPG.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: api/<CharacterController>
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return _characterService.GetCharacters();
        }

        // GET api/<CharacterController>/5
        [HttpGet("{id}")]
        public Character Get(int id)
        {
            return _characterService.GetCharacter(id);
        }

        // POST api/<CharacterController>
        [HttpPost]
        public void Post([FromBody] Character character)
        {
            // verify user?
            //Claim? principle = User.FindFirst(ClaimTypes.PrimarySid);

            //if (principle != null)
            //{
            //    character.UserId = principle.Value;
            //}

            _characterService.CreateUpdateCharacter(character);
        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _characterService.DeleteCharacter(id);
        }
    }
}
