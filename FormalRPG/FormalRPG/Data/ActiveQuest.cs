namespace FormalRPG.Data
{
    public class ActiveQuest
    {
        public int Id { get; set; }
        public QuestStatus Status { get; set; }
        public int CharacterId { get; set; }
        public int QuestId { get; set; }

        public Character Character { get; set; }
        public Quest Quest { get; set; }

    }

    public enum QuestStatus
    {
        TODO,
        DOING,
        DONE
    }
}
