﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SilencershopTest.DataAccess;

namespace SilencershopTest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SilencershopTest.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentDisposition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("SilencershopTest.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDisplayed")
                        .HasColumnType("bit");

                    b.Property<int?>("NotificationEventTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("NotificationEventTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SilencershopTest.Models.NotificationEventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotificationEventTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Event = "Created"
                        },
                        new
                        {
                            Id = 2,
                            Event = "Created a new Version of"
                        },
                        new
                        {
                            Id = 3,
                            Event = "Flagged"
                        });
                });

            modelBuilder.Entity("SilencershopTest.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("DeleteDocumentsOnExpiration")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FFLName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstThreeDigitOfFFL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastFiveDigitOfFFL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.HasIndex("UserStatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SilencershopTest.Models.UserLoginHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LogoutTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLoginHistories");
                });

            modelBuilder.Entity("SilencershopTest.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = "FFL/Admin"
                        },
                        new
                        {
                            Id = 2,
                            Role = "FFL/User"
                        },
                        new
                        {
                            Id = 3,
                            Role = "IOI/Admin"
                        },
                        new
                        {
                            Id = 4,
                            Role = "IOI/User"
                        });
                });

            modelBuilder.Entity("SilencershopTest.Models.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Enable"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Disable"
                        });
                });

            modelBuilder.Entity("SilencershopTest.Models.Document", b =>
                {
                    b.HasOne("SilencershopTest.Models.User", "UploadedBy")
                        .WithMany("Documents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SilencershopTest.Models.Notification", b =>
                {
                    b.HasOne("SilencershopTest.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId");

                    b.HasOne("SilencershopTest.Models.NotificationEventType", "NotificationEventType")
                        .WithMany()
                        .HasForeignKey("NotificationEventTypeId");

                    b.HasOne("SilencershopTest.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SilencershopTest.Models.User", b =>
                {
                    b.HasOne("SilencershopTest.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");

                    b.HasOne("SilencershopTest.Models.UserStatus", "UserStatus")
                        .WithMany()
                        .HasForeignKey("UserStatusId");
                });

            modelBuilder.Entity("SilencershopTest.Models.UserLoginHistory", b =>
                {
                    b.HasOne("SilencershopTest.Models.User", "User")
                        .WithMany("LoginHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
