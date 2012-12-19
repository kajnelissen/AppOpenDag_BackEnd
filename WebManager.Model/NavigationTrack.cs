using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebManager.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace WebManager.Model
{
    public class NavigationTrack : IEntity
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public NavigationRoute Route { get; set; }
    }
}