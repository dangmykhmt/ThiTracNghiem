using CaseStudy.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CaseStudy.Models
{
    public class trac_nghiem_onlineEntities : DbContext
    {
        public trac_nghiem_onlineEntities(DbContextOptions<trac_nghiem_onlineEntities> options) : base(options)
        {

        }

        public DbSet<question> questions { get; set; }
        public DbSet<quests_of_test> quests_of_test { get; set; }
        public DbSet<score> scores { get; set; }
        public DbSet<student> students { get; set; }
        public DbSet<subject> subjects { get; set; }
        public DbSet<test> tests { get; set; }
        public DbSet<student_test_detail> student_test_detail { get; set; }

        //public DbSet<NguoiDung> NguoiDungs { get; set; }
        //public DbSet<TheLoai> TheLoais { get; set; }
        //public DbSet<Thi> Thi { get; set; }
        //public DbSet<CauHoi> CauHois { get; set; }
        //public DbSet<DiemThi> DiemThis { get; set; }
        //public DbSet<DapAn> DapAns { get; set; }
        // public DbSet<CauHoiThi> CauHoiThi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<score>().HasKey(ct => new { ct.id_student, ct.id_score });
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


    }
}
