﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OpenDagBackEnd.Models
{
    public class Study
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength=1)]
        public string Name { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 1)]
        public string ShortName { get; set; }

        public int StudyInformationId { get; set; }

        public virtual ICollection<StudyInformation> Information { get; set; }
    }
}