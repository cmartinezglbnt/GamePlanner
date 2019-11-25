using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlanner.Web.Data.Entities
{
    public class Producer : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Document { get; set; }

        public double Salary { get; set; }

    }
}
