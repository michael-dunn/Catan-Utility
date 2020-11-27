﻿// <auto-generated />
using System;
using CatanUtility.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CatanUtility.Web.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CatanUtility.Classes.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("CatanUtility.Classes.BoardHex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BoardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Resource")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Robber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("BoardHex");
                });

            modelBuilder.Entity("CatanUtility.Classes.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("CatanUtility.Classes.Edge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BoardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Occupied")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Edge");
                });

            modelBuilder.Entity("CatanUtility.Classes.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BoardId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("CatanUtility.Classes.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("VictoryPoints")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("CatanUtility.Classes.Vertex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BoardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildingType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Occupied")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Vertex");
                });

            modelBuilder.Entity("CatanUtility.Classes.BoardHex", b =>
                {
                    b.HasOne("CatanUtility.Classes.Board", null)
                        .WithMany("Hexes")
                        .HasForeignKey("BoardId");
                });

            modelBuilder.Entity("CatanUtility.Classes.Card", b =>
                {
                    b.HasOne("CatanUtility.Classes.Player", null)
                        .WithMany("Hand")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("CatanUtility.Classes.Edge", b =>
                {
                    b.HasOne("CatanUtility.Classes.Board", null)
                        .WithMany("Edges")
                        .HasForeignKey("BoardId");
                });

            modelBuilder.Entity("CatanUtility.Classes.Game", b =>
                {
                    b.HasOne("CatanUtility.Classes.Board", "Board")
                        .WithMany()
                        .HasForeignKey("BoardId");

                    b.Navigation("Board");
                });

            modelBuilder.Entity("CatanUtility.Classes.Player", b =>
                {
                    b.HasOne("CatanUtility.Classes.Game", null)
                        .WithMany("Players")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("CatanUtility.Classes.Vertex", b =>
                {
                    b.HasOne("CatanUtility.Classes.Board", null)
                        .WithMany("Vertices")
                        .HasForeignKey("BoardId");
                });

            modelBuilder.Entity("CatanUtility.Classes.Board", b =>
                {
                    b.Navigation("Edges");

                    b.Navigation("Hexes");

                    b.Navigation("Vertices");
                });

            modelBuilder.Entity("CatanUtility.Classes.Game", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("CatanUtility.Classes.Player", b =>
                {
                    b.Navigation("Hand");
                });
#pragma warning restore 612, 618
        }
    }
}