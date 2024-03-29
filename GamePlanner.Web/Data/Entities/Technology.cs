﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GamePlanner.Web.Data.Entities
{
    public class Technology : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

    }
}

