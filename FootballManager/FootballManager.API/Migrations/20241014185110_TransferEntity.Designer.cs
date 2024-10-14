﻿// <auto-generated />
using FootballManager.API.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootballManager.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241014185110_TransferEntity")]
    partial class TransferEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FootballManager.API.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FootballManager.API.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FootballManager.API.Models.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("SourceTeamId")
                        .HasColumnType("int");

                    b.Property<int>("TargetTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SourceTeamId");

                    b.HasIndex("TargetTeamId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("FootballManager.API.Models.Player", b =>
                {
                    b.HasOne("FootballManager.API.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FootballManager.API.Models.Transfer", b =>
                {
                    b.HasOne("FootballManager.API.Models.Player", "Player")
                        .WithMany("Transfers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FootballManager.API.Models.Team", "SourceTeam")
                        .WithMany("OutgoingTransfers")
                        .HasForeignKey("SourceTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FootballManager.API.Models.Team", "TargetTeam")
                        .WithMany("IncomingTransfers")
                        .HasForeignKey("TargetTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("SourceTeam");

                    b.Navigation("TargetTeam");
                });

            modelBuilder.Entity("FootballManager.API.Models.Player", b =>
                {
                    b.Navigation("Transfers");
                });

            modelBuilder.Entity("FootballManager.API.Models.Team", b =>
                {
                    b.Navigation("IncomingTransfers");

                    b.Navigation("OutgoingTransfers");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
