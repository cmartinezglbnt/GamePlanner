using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlanner.Web.Data.Entities
{
    public class Concept : IEntity
    {
        public int Id { get; set; }

        public string Viability { get; set; }

        public string Risks { get; set; }
    }
}
