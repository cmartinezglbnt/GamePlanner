using GamePlanner.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamePlanner.Web.Models
{
    public class IdeasViewModel
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Features { get; set; }

        [Display(Name = "Gender")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a gender.")]
        public int GenderId { get; set; }

        public IEnumerable<SelectListItem> Genders { get; set; }

        [Display(Name = "Public")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a public.")]
        public int PublicId { get; set; }

        public IEnumerable<SelectListItem> Publics { get; set; }
    }
}
