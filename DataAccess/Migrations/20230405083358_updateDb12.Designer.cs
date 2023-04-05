﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(CICRequestContext))]
    [Migration("20230405083358_updateDb12")]
    partial class updateDb12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<short>("OperationClaimId")
                        .HasColumnType("smallint");

                    b.Property<short>("UserId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Concrete.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Entities.Concrete.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Entities.Concrete.Priority", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("Entities.Concrete.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<short>("CategoryId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 4, 5, 12, 33, 58, 664, DateTimeKind.Local).AddTicks(2008));

                    b.Property<int>("ExecutorId")
                        .HasColumnType("int");

                    b.Property<short>("PriorityId")
                        .HasColumnType("smallint");

                    b.Property<short>("RequestTypeId")
                        .HasColumnType("smallint");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<short>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)1);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("RequestTypeId");

                    b.HasIndex("SenderId");

                    b.HasIndex("StatusId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Entities.Concrete.RequestType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("Entities.Concrete.Status", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 4, 5, 12, 33, 58, 664, DateTimeKind.Local).AddTicks(1860));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("InnerPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MobilPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("NotificationPermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary(500)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary(500)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfilPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Concrete.Comment", b =>
                {
                    b.HasOne("Entities.Concrete.Request", "Request")
                        .WithMany("Comments")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.History", b =>
                {
                    b.HasOne("Entities.Concrete.User", "User")
                        .WithMany("Histories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.Request", b =>
                {
                    b.HasOne("Entities.Concrete.Category", "Category")
                        .WithMany("Requests")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.User", "Executor")
                        .WithMany("ExecutorRequests")
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Entities.Concrete.Priority", "Priority")
                        .WithMany("Requests")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.RequestType", "RequestType")
                        .WithMany("Requests")
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.User", "Sender")
                        .WithMany("SenderRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Entities.Concrete.Status", "Status")
                        .WithMany("Requests")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Executor");

                    b.Navigation("Priority");

                    b.Navigation("RequestType");

                    b.Navigation("Sender");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Entities.Concrete.Priority", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Entities.Concrete.Request", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Entities.Concrete.RequestType", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Entities.Concrete.Status", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ExecutorRequests");

                    b.Navigation("Histories");

                    b.Navigation("SenderRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
