using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FormalRPG.Data
{
    [Table("RpgUpgrades")]
    public class Upgrade
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Cost { get; set; }
        [NotNull]
        [MaxLength(255)]
        public string Name { get; set; } = "";
        [NotNull]
        [MaxLength(1000)]
        public string Description { get; set; } = "";

        public ICollection<Character> Characters { get; set; } = [];
    }
}
