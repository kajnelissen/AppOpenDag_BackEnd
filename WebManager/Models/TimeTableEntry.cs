﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebManager.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace WebManager.Models
{
    public class TimeTableEntry : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Location { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public int TimeTableId { get; set; }

        public TimeTable TimeTable { get; set; }
    }
}