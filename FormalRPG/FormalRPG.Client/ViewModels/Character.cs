

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FormalRPG.Client.ViewModels
{
    [Table("RpgCharacters")]
    public class Character
    {
        public int Id { get; set; }
        [NotNull]
        [MaxLength(255)]
        public string Name { get; set; } = "";
        public int Xp { get; set; }
        public int Money { get; set; }

        public ICollection<Skill> Skills { get; set; } = [];
        public ICollection<Quest> Quests { get; set; } = [];
        public ICollection<Upgrade> Upgrades { get; set; } = [];
        public ICollection<Item> Items { get; set; } = [];
    }
}
