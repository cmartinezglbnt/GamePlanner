using System;
using System.ComponentModel.DataAnnotations;

namespace GamePlanner.Web.Data.Entities
{
    public class Meeting : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "# Participants")]
        public int Num_Participants { get; set; }

        [Display(Name = "Participants")]
        public string Participants { get; set; }

        [Display(Name = "Date")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
