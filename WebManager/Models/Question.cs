using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebManager.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace WebManager.Models
{
    public class Question : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Text { get; set; }

        public int SurveyId { get; set; }

        public Survey Survey { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}