using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlanner.Web.Data.Entities
{
    public class Idea : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Features { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Public")]
        public int PublicId { get; set; }

        public Public Public { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
