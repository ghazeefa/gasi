using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeadlineManagementDB.FileUpload;
using DeadlineManagementDB.Supporting;
using DeadlineManagementDB.Users;

using System.ComponentModel.DataAnnotations.Schema;

namespace DeadlineManagementDB {
    public class DeadlineManagementContext : DbContext {


        public DeadlineManagementContext() : base("ComfortComplainceDeadlineDb") {
            this.Configuration.LazyLoadingEnabled = false;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            //---------------------Suporting Area Goes Here--------------------------------------
         //   modelBuilder.Entity<Company>().HasKey(u => u.Id).Property(u => u.Id)
         //   .HasColumnType("int")
         //   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         //   modelBuilder.Entity<Branch>().HasKey(u => u.Id).Property(u => u.Id)
         //  .HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         //   modelBuilder.Entity<Department>().HasKey(u => u.Id).Property(u => u.Id)
         //  .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         //   modelBuilder.Entity<FileType>().HasKey(u => u.Id).Property(u => u.Id)
         //  .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         //   modelBuilder.Entity<FileUploaded>().HasKey(u => u.Id).Property(u => u.Id)
         //  .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         //   modelBuilder.Entity<FileToUploadedDetail>().HasKey(u => u.Id).Property(u => u.Id)
         //  .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         //   modelBuilder.Entity<User>().HasKey(u => u.Id).Property(u => u.Id)
         //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //-----------------------------Relations-------------------------------------------//
            //    modelBuilder.Entity<Branch>()
            //        .HasRequired<Company>(u => u.company)
            //        .WithMany();
            //    modelBuilder.Entity<Department>()
            //    .HasRequired<Branch>(u => u.)
            //    .WithMany();
            //    modelBuilder.Entity<User>()
            //.HasRequired<Department>(u => u.department)
            //.WithMany();
            //    modelBuilder.Entity<User>()
            //.HasRequired<Branch>(u => u.branch)
            //.WithMany();
            //modelBuilder.Entity<FileToUploadedDetail>()
            //    .HasRequired<FileType>(u => u.filetype)
            //    .WithMany();
            //modelBuilder.Entity<FileUploaded>()
            //        .HasRequired<FileToUploadedDetail>(u => u.filuploaded)
            //        .WithMany();
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FileCategory> FileCategories { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<FileUploaded> FileUploades { get; set; }
        public DbSet<FileToUploadedDetail> FileToUploadedDetails { get; set; }

    }
}
