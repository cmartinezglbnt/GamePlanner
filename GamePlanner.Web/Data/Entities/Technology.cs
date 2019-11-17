using System;
using System.ComponentModel.DataAnnotations;

namespace GamePlanner.Web.Data.Entities
{
    public class Technology : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

    }
}

