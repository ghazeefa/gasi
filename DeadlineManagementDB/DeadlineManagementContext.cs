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


        public DeadlineManagementContext() : base("ComfortComplainceDeadline") {
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
        public DbSet<Company> companies { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<FileType> filetypes { get; set; }
        public DbSet<FileUploaded> fileuploades { get; set; }
        public DbSet<FileToUploadedDetail> filetouploadeddetails { get; set; }
    }
}
