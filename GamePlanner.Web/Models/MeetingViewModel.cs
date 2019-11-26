using GamePlanner.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlanner.Web.Models
{
    public class MeetingViewModel
    {
        public int Id { get; set; }

        [Display(Name = "# Participants")]
        public int Num_Participants { get; set; }

        [Display(Name = "Participants")]
        public string Participants { get; set; }

        [Display(Name = "Date")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public IEnumerable<Idea> Ideas { get; set; }
    }
}
