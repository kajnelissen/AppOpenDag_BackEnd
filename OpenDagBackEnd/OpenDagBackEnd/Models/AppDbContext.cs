using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace OpenDagBackEnd.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("AppDb")
        {
            //Database.SetInitializer(new WebTe);
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Study> Studies { get; set; }
        public DbSet<StudyInformation> StudyInfos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<TimeTableEntry> TimeTableEntries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<NavigationRoute> NavRoutes { get; set; }
        public DbSet<NavigationTrack> NavigationTracks { get; set; }
    }
}
 