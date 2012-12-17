using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebManager.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace WebManager.Models
{
    public class NavigationRoute : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength=1)]
        public string Name { get; set; }

        public virtual ICollection<NavigationTrack> Tracks { get; set; }
    }
}