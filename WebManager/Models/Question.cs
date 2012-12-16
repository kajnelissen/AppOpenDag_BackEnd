using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebManager.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int SurveyId { get; set; }

        public Survey Survey { get; set; }

        public virtual ICollection<Answer> Answers { get; set }
    }
}