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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Characters)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .HasPrincipalKey(u => u.Id);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Skills)
                .WithMany(s => s.Characters)
                .UsingEntity<Dictionary<int, int>>(
                    "RpgCharacterSkills",
                    r => r.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"));

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Quests)
                .WithMany(q => q.Characters)
                .UsingEntity<Dictionary<int, int>>(
                    "RpgActiveQuests",
                    r => r.HasOne<Quest>().WithMany().HasForeignKey("QuestId"),
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"));

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Upgrades)
                .WithMany(u => u.Characters)
                .UsingEntity<Dictionary<int, int>>(
                    "RpgAppliedUpgrades",
                    r => r.HasOne<Upgrade>().WithMany().HasForeignKey("UpgradeId"),
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"));

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Items)
                .WithMany(i => i.Characters)
                .UsingEntity<Dictionary<int, int>>(
                    "RpgOwnedItems",
                    e => e.HasOne<Item>().WithMany().HasForeignKey("ItemId"),
                    e => e.HasOne<Character>().WithMany().HasForeignKey("CharacterId"));

            modelBuilder.Entity<Quest>()
                .HasMany(q => q.Skills)
                .WithMany(s => s.Quests)
                .UsingEntity<Dictionary<int, int>>(
                    "RpgQuestSkills",
                    r => r.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                    l => l.HasOne<Quest>().WithMany().HasForeignKey("QuestId"));
        }
    }
}
