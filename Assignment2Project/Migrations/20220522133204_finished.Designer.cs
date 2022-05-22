﻿// <auto-generated />
using System;
using Assignment2Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment2Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220522133204_finished")]
    partial class finished
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Assignment2Project.Areas.Admin.Models.AssetCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AssetCategories");
                });

            modelBuilder.Entity("Assignment2Project.Models.AssetModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RoomId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("Assignment2Project.Models.CustomUserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InstitutionId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1a4df6c2-e479-40eb-8135-d492174424f2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "76a518b4-92f0-4b97-b4c2-86bb109ef976",
                            Email = "admin@estates.com",
                            EmailConfirmed = false,
                            Fname = "Admin",
                            InstitutionId = 1,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ESTATES.COM",
                            NormalizedUserName = "ADMIN@ESTATES.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEO1Tj9sSN5WkABSZDh17rt0y949atfRorSqJzlF63ZmYTh9P6PzjrenHwlEYlTnGEQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7752520d-4184-428d-ac11-4face6286167",
                            Sname = "Admin",
                            TwoFactorEnabled = false,
                            UserName = "admin@estates.com"
                        });
                });

            modelBuilder.Entity("Assignment2Project.Models.GeneralCommentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GeneralIssueId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GeneralIssueModelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GeneralIssueModelId");

                    b.HasIndex("UserId");

                    b.ToTable("GeneralComments");
                });

            modelBuilder.Entity("Assignment2Project.Models.GeneralIssueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateRaised")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InstitutionId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("UserId");

                    b.ToTable("GeneralIssues");
                });

            modelBuilder.Entity("Assignment2Project.Models.GeneralResolutionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateResolved")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GeneralIssueId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GeneralIssueModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GeneralIssueModelId");

                    b.HasIndex("UserId");

                    b.ToTable("GeneralResolutionModel");
                });

            modelBuilder.Entity("Assignment2Project.Models.InstitutionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TelephoneNum")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Institutions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "",
                            Name = "Default",
                            TelephoneNum = ""
                        });
                });

            modelBuilder.Entity("Assignment2Project.Models.MaintenanceCommentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaintenanceIssueId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaintenanceIssueModelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceIssueModelId");

                    b.HasIndex("UserId");

                    b.ToTable("MaintenanceComments");
                });

            modelBuilder.Entity("Assignment2Project.Models.MaintenanceIssueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InstitutionId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeRaised")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("MaintenanceIssues");
                });

            modelBuilder.Entity("Assignment2Project.Models.ResolutionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateResolved")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaintenanceIssueId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaintenanceIssueModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceIssueModelId");

                    b.HasIndex("UserId");

                    b.ToTable("Resolutions");
                });

            modelBuilder.Entity("Assignment2Project.Models.RoomCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RoomCategories");
                });

            modelBuilder.Entity("Assignment2Project.Models.RoomModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstitutionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1a43ecdc-e161-4cc2-8476-004e461304fd",
                            ConcurrencyStamp = "48c7b087-13b9-46bd-b10f-9566e89276ab",
                            Name = "Estates_Admin",
                            NormalizedName = "ESTATES_ADMIN"
                        },
                        new
                        {
                            Id = "875ea618-c65e-4eac-9c0f-4a59f1ddaa2c",
                            ConcurrencyStamp = "7684f586-4a4d-4b14-b09c-a1a936cd4c8d",
                            Name = "Estates_Staff",
                            NormalizedName = "ESTATES_STAFF"
                        },
                        new
                        {
                            Id = "fd32bd40-c6ba-474a-b959-55a3a8941347",
                            ConcurrencyStamp = "3a8cfa8f-22b3-4323-ae1a-11884ac4ba6d",
                            Name = "Institution_Manager",
                            NormalizedName = "INSTITUTION_MANAGER"
                        },
                        new
                        {
                            Id = "35981c10-0352-46be-9b0b-769ce6d85af9",
                            ConcurrencyStamp = "16e1cc37-4269-4096-880c-53b14399beff",
                            Name = "Institution_Staff",
                            NormalizedName = "INSTITUTION_STAFF"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1a4df6c2-e479-40eb-8135-d492174424f2",
                            RoleId = "35981c10-0352-46be-9b0b-769ce6d85af9"
                        },
                        new
                        {
                            UserId = "1a4df6c2-e479-40eb-8135-d492174424f2",
                            RoleId = "fd32bd40-c6ba-474a-b959-55a3a8941347"
                        },
                        new
                        {
                            UserId = "1a4df6c2-e479-40eb-8135-d492174424f2",
                            RoleId = "875ea618-c65e-4eac-9c0f-4a59f1ddaa2c"
                        },
                        new
                        {
                            UserId = "1a4df6c2-e479-40eb-8135-d492174424f2",
                            RoleId = "1a43ecdc-e161-4cc2-8476-004e461304fd"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Assignment2Project.Models.AssetModel", b =>
                {
                    b.HasOne("Assignment2Project.Areas.Admin.Models.AssetCategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2Project.Models.RoomModel", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Assignment2Project.Models.CustomUserModel", b =>
                {
                    b.HasOne("Assignment2Project.Models.InstitutionModel", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("Assignment2Project.Models.GeneralCommentModel", b =>
                {
                    b.HasOne("Assignment2Project.Models.GeneralIssueModel", null)
                        .WithMany("GeneralComments")
                        .HasForeignKey("GeneralIssueModelId");

                    b.HasOne("Assignment2Project.Models.CustomUserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignment2Project.Models.GeneralIssueModel", b =>
                {
                    b.HasOne("Assignment2Project.Models.InstitutionModel", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2Project.Models.CustomUserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignment2Project.Models.GeneralResolutionModel", b =>
                {
                    b.HasOne("Assignment2Project.Models.GeneralIssueModel", null)
                        .WithMany("ResolutionComments")
                        .HasForeignKey("GeneralIssueModelId");

                    b.HasOne("Assignment2Project.Models.CustomUserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignment2Project.Models.MaintenanceCommentModel", b =>
                {
                    b.HasOne("Assignment2Project.Models.MaintenanceIssueModel", null)
                        .WithMany("MaintenanceComments")
                        .HasForeignKey("MaintenanceIssueModelId");

                    b.HasOne("Assignment2Project.Models.CustomUserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignment2Project.Models.MaintenanceIssueModel", b =>
                {
                    b.HasOne("Assignment2Project.Models.AssetModel", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2Project.Models.InstitutionModel", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2Project.Models.RoomModel", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2Project.Models.CustomUserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Institution");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignment2Project.Models.ResolutionModel", b =>
                {
                    b.HasOne("Assignment2Project.Models.MaintenanceIssueModel", null)
                        .WithMany("ResolutionComments")
                        .HasForeignKey("MaintenanceIssueModelId");

                    b.HasOne("Assignment2Project.Models.CustomUserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignment2Project.Models.RoomModel", b =>
                {
                    b.HasOne("Assignment2Project.Models.RoomCategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2Project.Models.InstitutionModel", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Assignment2Project.Models.CustomUserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Assignment2Project.Models.CustomUserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2Project.Models.CustomUserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Assignment2Project.Models.CustomUserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment2Project.Models.GeneralIssueModel", b =>
                {
                    b.Navigation("GeneralComments");

                    b.Navigation("ResolutionComments");
                });

            modelBuilder.Entity("Assignment2Project.Models.MaintenanceIssueModel", b =>
                {
                    b.Navigation("MaintenanceComments");

                    b.Navigation("ResolutionComments");
                });
#pragma warning restore 612, 618
        }
    }
}
