using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlanner.Web.Data.Entities
{
    public class Meeting : IEntity
    {
        public int Id { get; set; }

        public int Num_Participants { get; set; }

        public string Participants { get; set; }

        public DateTime Fecha { get; set; }
    }
}
