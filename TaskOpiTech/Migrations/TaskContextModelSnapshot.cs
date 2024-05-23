﻿// <auto-generated />
using System;
using Infrastructure.TaskContens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace TaskOpiTech.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.TaskEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("Priority")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("State")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Preference")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "9ce0d181-f99e-48dd-ae1d-dbc19093a0f1",
                            Email = "alejo@gmail.com",
                            Name = "Alejandro Hurtado",
                            Password = "123456",
                            Preference = 0
                        });
                });

            modelBuilder.Entity("Domain.Models.TaskEntity", b =>
                {
                    b.HasOne("Domain.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
