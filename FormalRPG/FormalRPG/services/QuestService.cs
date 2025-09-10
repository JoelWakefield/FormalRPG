using FormalRPG.Data;
using Microsoft.EntityFrameworkCore;

namespace FormalRPG.services
{
    public interface IQuestService
    {
        public List<Quest> GetQuests();
        public Quest GetQuest(int id);
        public Quest GetActiveQuest(int id);
        public List<Quest> GetCharacterActiveQuests(int characterId);
        public void AcceptQuest(int questId, int characterId);
        public void UpdateQuest(int id, QuestStatus status);
    }

    public class QuestService : IQuestService
    {
        private readonly ApplicationDbContext _context;

        public QuestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Quest> GetQuests()
        {
            return _context.Quests.ToList();
        }

        public Quest GetQuest(int id)
        {
            return _context.Quests.FirstOrDefault(q => q.Id == id) ?? new Quest();
        }

        public Quest GetActiveQuest(int id)
        {
            return _context.ActiveQuests.FirstOrDefault(a => a.Id == id)?.Quest ?? new Quest();
        }

        public List<Quest> GetCharacterActiveQuests(int characterId)
        {
            return _context.ActiveQuests
                .Where(a => a.CharacterId == characterId)
                .Select(a => a.Quest)
                .ToList();
        }

        public void AcceptQuest(int questId, int characterId)
        {
            Quest? quest = _context.Quests.FirstOrDefault(q => q.Id == questId);
            Character? character = _context.Characters.FirstOrDefault(c => c.Id == characterId);

            if (quest != null && character != null)
            {
                _context.ActiveQuests.Add(new ActiveQuest() { 
                    QuestId = questId, 
                    CharacterId = characterId,
                    Quest = quest,
                    Character = character,
                    Status = QuestStatus.TODO,
                });
                _context.SaveChanges();
            }
        }

        public void UpdateQuest(int id, QuestStatus status)
        {
            ActiveQuest? activeQuest = _context.ActiveQuests.FirstOrDefault(a => a.Id == id);

            if (activeQuest != null)
            {
                activeQuest.Status = status;
                _context.SaveChanges();
            }
        }
    }
}
