using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebManager.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace WebManager.Model
{
    public class StudyInformation : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int StudyId { get; set; }

        public Study Study { get; set; }
    }
}