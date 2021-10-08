using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FileManager.Data;
using FileManager.Data.Seed;

namespace FileManager.Repository
{
    public class FileManagerDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Submission> Submissions {get; set;}
        public DbSet<SubmissionFile> SubmissionFiles {get; set;}

        public FileManagerDbContext(DbContextOptions<FileManagerDbContext> options): base(options) { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            new SubmissionConfig(modelBuilder.Entity<Submission>());
            new SubmissionFileConfig(modelBuilder.Entity<SubmissionFile>());

            //Seed Data
            modelBuilder.Seed();
        }

    }
}