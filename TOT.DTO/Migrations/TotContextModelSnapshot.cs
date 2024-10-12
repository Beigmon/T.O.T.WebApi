﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using T.O.T.DTO;
using TOT.DTO;

#nullable disable

namespace T.O.T.DTO.Migrations
{
    [DbContext(typeof(TotContext))]
    partial class TotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("T.O.T.DTO.Models.Configuration.BotConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DiscordServerId")
                        .HasColumnType("integer");

                    b.Property<string>("StartggToken")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DiscordServerId")
                        .IsUnique();

                    b.ToTable("BotConfigurations");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Configuration.DiscordConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomPrefix")
                        .HasColumnType("text");

                    b.Property<int>("DiscordServerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DiscordServerId")
                        .IsUnique();

                    b.ToTable("DiscordConfigurations");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Discord.DiscordRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BotConfigurationId")
                        .HasColumnType("integer");

                    b.Property<decimal>("DiscordId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("BotConfigurationId");

                    b.ToTable("DiscordRoles");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Discord.DiscordServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DiscordGuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("DiscordName")
                        .HasColumnType("text");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReferenceUser")
                        .HasColumnType("text");

                    b.Property<bool>("RunningTournament")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("DiscordServers");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Player.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("StartggId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Player.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("StartggUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Player.PlayerCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer");

                    b.Property<int>("Occurrence")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerCharacters");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.TournamentRelated.EventDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<int>("StartggId")
                        .HasColumnType("integer");

                    b.Property<int>("TournamentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("EventDto");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.TournamentRelated.TournamentDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DiscordServerId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StartggId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DiscordServerId");

                    b.ToTable("TournamentDto");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Configuration.BotConfiguration", b =>
                {
                    b.HasOne("T.O.T.DTO.Models.Discord.DiscordServer", "DiscordServer")
                        .WithOne("BotConfiguration")
                        .HasForeignKey("T.O.T.DTO.Models.Configuration.BotConfiguration", "DiscordServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscordServer");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Configuration.DiscordConfiguration", b =>
                {
                    b.HasOne("T.O.T.DTO.Models.Discord.DiscordServer", "DiscordServer")
                        .WithOne("DiscordConfiguration")
                        .HasForeignKey("T.O.T.DTO.Models.Configuration.DiscordConfiguration", "DiscordServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscordServer");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Discord.DiscordRole", b =>
                {
                    b.HasOne("T.O.T.DTO.Models.Configuration.BotConfiguration", "BotConfiguration")
                        .WithMany("AllowedSetChannelsRoles")
                        .HasForeignKey("BotConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BotConfiguration");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Player.PlayerCharacter", b =>
                {
                    b.HasOne("T.O.T.DTO.Models.Player.Character", "Character")
                        .WithMany("PlayerCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("T.O.T.DTO.Models.Player.Player", "Player")
                        .WithMany("PlayerCharacters")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.TournamentRelated.EventDto", b =>
                {
                    b.HasOne("T.O.T.DTO.Models.TournamentRelated.TournamentDto", "Tournament")
                        .WithMany("Events")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.TournamentRelated.TournamentDto", b =>
                {
                    b.HasOne("T.O.T.DTO.Models.Discord.DiscordServer", "DiscordServer")
                        .WithMany("Tournaments")
                        .HasForeignKey("DiscordServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscordServer");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Configuration.BotConfiguration", b =>
                {
                    b.Navigation("AllowedSetChannelsRoles");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Discord.DiscordServer", b =>
                {
                    b.Navigation("BotConfiguration")
                        .IsRequired();

                    b.Navigation("DiscordConfiguration");

                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Player.Character", b =>
                {
                    b.Navigation("PlayerCharacters");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.Player.Player", b =>
                {
                    b.Navigation("PlayerCharacters");
                });

            modelBuilder.Entity("T.O.T.DTO.Models.TournamentRelated.TournamentDto", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
