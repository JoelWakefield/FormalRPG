using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FormalRPG.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Characters)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .HasPrincipalKey(u => u.Id);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Skills)
                .WithMany(s => s.Characters)
                .UsingEntity(
                    "RpgCharacterSkills",
                    l => l.HasOne(typeof(Character)).WithMany().HasForeignKey("CharacterId").HasPrincipalKey(nameof(Character.Id)),
                    r => r.HasOne(typeof(Skill)).WithMany().HasForeignKey("SkillId").HasPrincipalKey(nameof(Skill.Id)),
                    j => j.HasKey("CharacterId", "SkillId"));

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Quests)
                .WithMany(q => q.Characters)
                .UsingEntity(
                    "RpgActiveQuests",
                    l => l.HasOne(typeof(Character)).WithMany().HasForeignKey("CharacterId").HasPrincipalKey(nameof(Character.Id)),
                    r => r.HasOne(typeof(Quest)).WithMany().HasForeignKey("QuestId").HasPrincipalKey(nameof(Quest.Id)),
                    j => j.HasKey("CharacterId", "QuestId"));

            modelBuilder.Entity<Quest>()
                .HasMany(q => q.Skills)
                .WithMany(s => s.Quests)
                .UsingEntity(
                    "RpgQuestSkills",
                    l => l.HasOne(typeof(Quest)).WithMany().HasForeignKey("QuestId").HasPrincipalKey(nameof(Quest.Id)),
                    r => r.HasOne(typeof(Item)).WithMany().HasForeignKey("SkillId").HasPrincipalKey(nameof(Skill.Id)),
                    j => j.HasKey("QuestId", "SkillId"));

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Upgrades)
                .WithMany(u => u.Characters)
                .UsingEntity(
                    "RpgAppliedUpgrades",
                    l => l.HasOne(typeof(Character)).WithMany().HasForeignKey("CharacterId").HasPrincipalKey(nameof(Character.Id)),
                    r => r.HasOne(typeof(Upgrade)).WithMany().HasForeignKey("UpgradeId").HasPrincipalKey(nameof(Upgrade.Id)),
                    j => j.HasKey("CharacterId", "UpgradeId"));

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Items)
                .WithMany(i => i.Characters)
                .UsingEntity(
                    "RpgOwnedItems",
                    l => l.HasOne(typeof(Character)).WithMany().HasForeignKey("CharacterId").HasPrincipalKey(nameof(Character.Id)),
                    r => r.HasOne(typeof(Item)).WithMany().HasForeignKey("ItemId").HasPrincipalKey(nameof(Item.Id)),
                    j => j.HasKey("CharacterId", "ItemId"));
        }
    }
}
