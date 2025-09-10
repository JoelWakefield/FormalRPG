using FormalRPG.Data;
using FormalRPG.services;
using Microsoft.AspNetCore.Mvc;

namespace FormalRPG.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IQuestService _questService;

        public QuestController(IQuestService questService)
        {
            _questService = questService;
        }

        // GET: api/<QuestController>
        [HttpGet]
        public IEnumerable<Quest> Get()
        {
            return _questService.GetQuests();
        }

        // GET api/<QuestController>/5
        [HttpGet("{id}")]
        public Quest Get(int id)
        {
            return _questService.GetQuest(id);
        }

        // POST api/<QuestController>
        [HttpPost("update")]
        public void Post([FromBody] int questId, QuestStatus status)
        {
            _questService.UpdateQuest(questId, status);
        }
    }
}
