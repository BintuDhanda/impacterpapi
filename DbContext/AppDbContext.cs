﻿using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.ERPDbContext
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
       {
       }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Roles> Roles { get; set;}
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Batch> Batch { get; set; }
        public DbSet<CourseCategory> CourseCategory { get; set; }
        public DbSet<StudentBatch> StudentBatch { get;set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Pincode> Pincode { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountCategory> AccountCategory { get; set; }
        public DbSet<DayBook> DayBook { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<StudentQualification> StudentQualification { get; set; }
        public DbSet<StudentContact> StudentContact { get; set; }
        public DbSet<StudentAddress> StudentAddress { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<StudentToken> StudentToken { get; set; }
        public DbSet<TokenValidity> TokenValidity { get; set; }
        public DbSet<Registration> Registration{ get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentFees> StudentFees { get; set; }
        public DbSet<FeeType> FeeType { get; set; }
    }
}