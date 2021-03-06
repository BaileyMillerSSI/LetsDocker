﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;
using ToDoService.Entity;

namespace ToDoService.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20181006102421_OrderSorting")]
    partial class OrderSorting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("ToDoService.Entity.AgendaItem", b =>
                {
                    b.Property<int>("AgendaItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("DueBy");

                    b.Property<int>("PriorityOrder");

                    b.Property<string>("Title");

                    b.HasKey("AgendaItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ToDoService.Entity.AgendaPicture", b =>
                {
                    b.Property<int>("AgendaPictureId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgendaItemId");

                    b.Property<byte[]>("BinaryPictureData");

                    b.HasKey("AgendaPictureId");

                    b.HasIndex("AgendaItemId")
                        .IsUnique();

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("ToDoService.Entity.AgendaPicture", b =>
                {
                    b.HasOne("ToDoService.Entity.AgendaItem", "AgendaItem")
                        .WithOne("AgendaPicture")
                        .HasForeignKey("ToDoService.Entity.AgendaPicture", "AgendaItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
