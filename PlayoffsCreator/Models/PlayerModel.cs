using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PlayoffsCreator.Models
{
    public class PlayerModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [Display(Name="Team name")]
        [Required]
        [RegularExpression("^(?!No team in DB$).*$", ErrorMessage = "No valid team selected (Team should be added to database).")]
        public string TeamName { get; set; }
    }
}