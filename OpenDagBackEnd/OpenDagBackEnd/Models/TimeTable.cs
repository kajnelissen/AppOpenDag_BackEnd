using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OpenDagBackEnd.Models
{
    public class TimeTable
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<TimeTableEntry> TimeTableEntries { get; set; }
    }
}