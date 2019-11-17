﻿using System;
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

        public string Description { get; set; }

        public string Features { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }

        public int PublicId { get; set; }

        public Public Public { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
