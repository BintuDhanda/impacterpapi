using ERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace ERP.ERPDbContext
{
    public static class Seeder
    {
        public static void RoleSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 6, RoleName = "UserScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 7, RoleName = "RolesScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 8, RoleName = "StudentDetailsScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 9, RoleName = "QualificationScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 10, RoleName = "CountryScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 11, RoleName = "CourseCategoryScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 12, RoleName = "AddressTypeScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 13, RoleName = "EnterAccountScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 14, RoleName = "StudentBatchFeesScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 15, RoleName = "StudentTokenFeesScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 16, RoleName = "AttendanceScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 17, RoleName = "NewsScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 18, RoleName = "SendNotificationScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 19, RoleName = "IdentityTypeScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 20, RoleName = "SliderScreen", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 21, RoleName = "Hostels", IsStatic = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RolesId = 22, RoleName = "StudentHostelRoomBads", IsStatic = true });
        }
    }
}
