using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FormalRPG.Client.ViewModels
{
    [Table("RpgSkills")]
    public class Skill
    {
        public int Id { get; set; }
        [NotNull]
        [MaxLength(255)]
        public string Name { get; set; } = "";

        public ICollection<Character> Characters { get; set; } = [];
        public ICollection<Quest> Quests { get; set; } = [];
    }
}
