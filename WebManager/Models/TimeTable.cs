using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebManager.Models
{
    public class TimeTable
    {
        public int Id { get; set; }

        public virtual ICollection<TimeTableEntry> TimeTableEntries { get; set; }
    }
}