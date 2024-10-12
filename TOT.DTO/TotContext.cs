using Microsoft.EntityFrameworkCore;
using TOT.DTO.Models.Configuration;
using TOT.DTO.Models.Discord;
using TOT.DTO.Models.Player;
using TOT.DTO.Models.TournamentRelated;

namespace TOT.DTO
{
    public class TotContext(DbContextOptions<TotContext> options) : DbContext(options)
    {
        public DbSet<DiscordServer> DiscordServers { get; set; } = default!;
        public DbSet<DiscordConfiguration> DiscordConfigurations { get; set; } = default!;
        public DbSet<BotConfiguration> BotConfigurations { get; set; } = default!;
        public DbSet<DiscordRole> DiscordRoles { get; set; } = default!;

        public DbSet<PlayerCharacter> PlayerCharacters { get; set; } = default!;
        public DbSet<Player> Players { get; set; } = default!;
        public DbSet<Character> Characters { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();

            // DiscordServer
            modelBuilder.Entity<DiscordServer>()
                .HasOne(e => e.BotConfiguration)
                .WithOne(e => e.DiscordServer)
                .HasForeignKey<BotConfiguration>(e => e.DiscordServerId)
                .IsRequired();

            modelBuilder.Entity<DiscordServer>()
                .HasOne(e => e.DiscordConfiguration)
                .WithOne(e => e.DiscordServer)
                .HasForeignKey<DiscordConfiguration>(e => e.DiscordServerId)
                .IsRequired();

            modelBuilder.Entity<DiscordServer>()
                .HasMany(e => e.Tournaments)
                .WithOne(e => e.DiscordServer)
                .HasForeignKey(e => e.DiscordServerId)
                .IsRequired();

            // Bot Configuration
            modelBuilder.Entity<BotConfiguration>()
                .HasMany(e => e.AllowedSetChannelsRoles)
                .WithOne(e => e.BotConfiguration)
                .HasForeignKey(e => e.BotConfigurationId)
                .IsRequired();

            // Character
            modelBuilder.Entity<Character>()
                .HasMany(e => e.PlayerCharacters)
                .WithOne(e => e.Character)
                .HasForeignKey(e => e.CharacterId)
                .IsRequired();

            // Player
            modelBuilder.Entity<Player>()
                .HasMany(e => e.PlayerCharacters)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.PlayerId)
                .IsRequired();

            // Tournament
            modelBuilder.Entity<TournamentDto>()
                .HasMany(e => e.Events)
                .WithOne(e => e.Tournament)
                .HasForeignKey(e => e.TournamentId)
                .IsRequired();
        }
    }
}
