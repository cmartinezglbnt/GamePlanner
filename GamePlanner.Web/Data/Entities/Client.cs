using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlanner.Web.Data.Entities
{
    public class Client : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Document { get; set; }

        public string Company { get; set; }

    }
}
