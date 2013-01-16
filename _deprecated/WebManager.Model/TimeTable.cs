using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebManager.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace WebManager.Model
{
    public class TimeTable : IEntity
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<TimeTableEntry> TimeTableEntries { get; set; }
    }
}