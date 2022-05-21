using Assignment2Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment2Project.Areas.Admin.Models;

namespace Assignment2Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUserModel>
    {
        public DbSet<InstitutionModel> Institutions { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<RoomCategoryModel> RoomCategories { get; set;}
        public DbSet<AssetModel> Assets { get; set; }
        public DbSet<AssetCategoryModel> AssetCategories { get; set; }
        public DbSet<MaintenanceIssueModel> MaintenanceIssues { get; set;}
        public DbSet<GeneralIssueModel> GeneralIssues { get; set; }
        public DbSet<MaintenanceCommentModel> MaintenanceComments { get; set;}
        public DbSet<GeneralCommentModel> GeneralComments { get; set; }
        public DbSet<ResolutionModel> Resolutions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedInstitution(builder);
            SeedAdmin(builder);
            SeedRoles(builder);
            SeedUserRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "1a43ecdc-e161-4cc2-8476-004e461304fd",
                    Name = "Estates_Admin",
                    NormalizedName = "Estates_Admin".ToUpper(),
                    ConcurrencyStamp = "48c7b087-13b9-46bd-b10f-9566e89276ab"
                }
                );
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole()
               {
                   Id = "875ea618-c65e-4eac-9c0f-4a59f1ddaa2c",
                   Name = "Estates_Staff",
                   NormalizedName = "Estates_Staff".ToUpper(),
                   ConcurrencyStamp = "7684f586-4a4d-4b14-b09c-a1a936cd4c8d"
               }
               );
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = "fd32bd40-c6ba-474a-b959-55a3a8941347",
                Name = "Institution_Manager",
                NormalizedName = "Institution_Manager".ToUpper(),
                ConcurrencyStamp = "3a8cfa8f-22b3-4323-ae1a-11884ac4ba6d"
            }
            );
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = "35981c10-0352-46be-9b0b-769ce6d85af9",
                Name = "Institution_Staff",
                NormalizedName = "Institution_Staff".ToUpper(),
                ConcurrencyStamp = "16e1cc37-4269-4096-880c-53b14399beff"
            }
            );
        }


        private void SeedInstitution(ModelBuilder builder)
        {
            InstitutionModel institution = new InstitutionModel()
            {
                Id = 1,
                Name = "Default",
                TelephoneNum = String.Empty,
                Address = String.Empty
            };
            builder.Entity<InstitutionModel>().HasData(institution);
        }

        private void SeedAdmin(ModelBuilder builder)
        {
            PasswordHasher<CustomUserModel> hasher = new PasswordHasher<CustomUserModel>();
            CustomUserModel user = new CustomUserModel();
            user.Id = "1a4df6c2-e479-40eb-8135-d492174424f2";
            user.UserName = "admin@estates.com";
            user.NormalizedUserName = "admin@estates.com".ToUpper();
            user.NormalizedEmail = "admin@estates.com".ToUpper();
            user.Email = "admin@estates.com";
            user.LockoutEnabled = false;
            user.Fname = "Admin";
            user.Sname = "Admin";
            user.ConcurrencyStamp = "76a518b4-92f0-4b97-b4c2-86bb109ef976";
            user.PasswordHash = hasher.HashPassword(user, "Admin123!");
            user.InstitutionId = 1;
            builder.Entity<CustomUserModel>().HasData(user);

        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "35981c10-0352-46be-9b0b-769ce6d85af9",
                    UserId = "1a4df6c2-e479-40eb-8135-d492174424f2"
                }
                );
            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>()
               {
                   RoleId = "fd32bd40-c6ba-474a-b959-55a3a8941347",
                   UserId = "1a4df6c2-e479-40eb-8135-d492174424f2"
               }
               );
            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>()
               {
                   RoleId = "875ea618-c65e-4eac-9c0f-4a59f1ddaa2c",
                   UserId = "1a4df6c2-e479-40eb-8135-d492174424f2"
               }
               );
            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>()
               {
                   RoleId = "1a43ecdc-e161-4cc2-8476-004e461304fd",
                   UserId = "1a4df6c2-e479-40eb-8135-d492174424f2"
               }
               );
        }

        

    }
}