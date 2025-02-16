using Idestro.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Idestro.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //複合キーはHasKeyで設定
            modelBuilder.Entity<ConvertFile>().HasKey(e => new { e.ProjectDesc, e.JobDesc, e.FmtNo, e.FileDesc });
            modelBuilder.Entity<FieldMst>().HasKey(e => new { e.ProjectDesc, e.JobDesc, e.FmtNo, e.FldNo });
            modelBuilder.Entity<JobMst>().HasKey(e => new { e.ProjectDesc, e.JobDesc});
        }

        public DbSet<ConvertFile> ConvertFiles => Set<ConvertFile>();
        public DbSet<FieldMst> FieldMst => Set<FieldMst>();
        public DbSet<ProjectMst> ProjectMst => Set<ProjectMst>();
        public DbSet<JobMst> JobMst => Set<JobMst>();
    }
}
