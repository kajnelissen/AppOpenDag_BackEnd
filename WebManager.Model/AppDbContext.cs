using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace WebManager.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }

        public AppDbContext()
            : base("AppDb")
        {
            //Database.SetInitializer(new WebTe);
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<NavigationRoute> NavRoutes { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<StudyInformation> StudyInfos { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<TimeTable> TimeTables { get; set; }

        public DbSet<TimeTableEntry> TimeTableEntries { get; set; }
    }
}
 