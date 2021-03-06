﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperheroCreator.Models
{
    public class Superhero
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Hero Name")]
        public string HeroName { get; set; }
        public string AlterEgo { get; set; }
        public string PrimaryAbility { get; set; }
        public string SecondaryAbility{ get; set; }
        public string Catchprhase { get; set; }
    }
}