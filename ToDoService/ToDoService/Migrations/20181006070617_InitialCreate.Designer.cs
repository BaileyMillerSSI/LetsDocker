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
    [Migration("20181006070617_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("DueBy");

                    b.Property<string>("Title");

                    b.HasKey("AgendaItemId");

                    b.ToTable("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
