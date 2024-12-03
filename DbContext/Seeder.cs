using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.ERPDbContext
{
    public static class Seeder
    {
        public static void RoleSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 1, RoleName = "Admin", IsStatic = false });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 2, RoleName = "Staff", IsStatic = false });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 3, RoleName = "Student", IsStatic = false });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 4, RoleName = "UserScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 5, RoleName = "RolesScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 6, RoleName = "StudentDetailsScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 7, RoleName = "QualificationScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 8, RoleName = "CountryScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 9, RoleName = "CourseCategoryScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 10, RoleName = "AddressTypeScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 11, RoleName = "EnterAccountScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 12, RoleName = "StudentBatchFeesScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 13, RoleName = "StudentTokenFeesScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 14, RoleName = "AttendanceScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 15, RoleName = "NewsScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 16, RoleName = "SendNotificationScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 17, RoleName = "IdentityTypeScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 18, RoleName = "SliderScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 19, RoleName = "Hostels", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 20, RoleName = "StudentHostelRoomBads", IsStatic = true });
        }

        public static void UserSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(new Users { UsersId = 1, UserMobile = "9416669174", UserEmail = "bn2mehlan510@gmail.com", UserPassword = "Admin@123", IsActive = true, IsDeleted = false, IsEmailConfirmed = true, IsMobileConfirmed = true });
            modelBuilder.Entity<Users>().HasData(new Users { UsersId = 2, UserMobile = "9991339400", UserEmail = "admin@admin.com", UserPassword = "Admin@123", IsActive = true, IsDeleted = false, IsEmailConfirmed = true, IsMobileConfirmed = true });
        }

        public static void UserRoleSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(new UserRole { UserRoleId = 1, UserID = 1, RoleID = 1, IsDeleted = false, IsActive = true });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { UserRoleId = 2, UserID = 2, RoleID = 1, IsDeleted = false, IsActive = true });
        }

        public static void AcademySeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academy>().HasData(new Academy { AcademyId = 1, AcademyName = "Impact Academy, Hisar" });
            modelBuilder.Entity<Academy>().HasData(new Academy { AcademyId = 2, AcademyName = "Impact Academy, Chaudhariwas" });
        }
    }
}
