using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FormalRPG.Data
{
    [Table("RpgQuests")]
    public class Quest
    {
        public int Id { get; set; }
        [NotNull]
        [MaxLength(255)]
        public string Name { get; set; } = "";

        [NotMapped]
        public bool Completed { get; set; }

        public ICollection<ActiveQuest> Active { get; set; }
        public ICollection<Skill> Skills { get; set; } = [];
    }
}
