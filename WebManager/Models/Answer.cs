using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebManager.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Answer
    {
        public int AnswerId { get; set; }

        [Required]
        [StringLength(80, MinimumLength=1)]
        public string Text { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public IDictionary<Study, int> StudyRatings { get; set; }
    }
}