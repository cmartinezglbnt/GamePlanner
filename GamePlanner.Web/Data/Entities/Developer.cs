using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlanner.Web.Data.Entities
{
    public class Developer : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Document { get; set; }

        public string Rol { get; set; }

        public string Specialization { get; set; }

        public double Salary { get; set; }

    }
}
