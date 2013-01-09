using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OpenDagBackEnd.Models
{
    public class NavigationRoute
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength=1)]
        public string Name { get; set; }

        public virtual ICollection<NavigationTrack> Tracks { get; set; }
    }
}