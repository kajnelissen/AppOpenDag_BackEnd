using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebManager.Models
{
    public class Study
    {
        public int StudyId { get; set; }

        [StringLength(50, MinimumLength=1)]
        public string Name { get; set; }
    }
}