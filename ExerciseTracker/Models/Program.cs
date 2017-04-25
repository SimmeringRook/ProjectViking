using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExerciseTracker.Models
{
    public class Program
    {
        [ScaffoldColumn(false)]
        public int ProgramID { get; set; }

        [Required, Display(Name = "Name")]
        public string ProgramName { get; set; }
        
        internal virtual ICollection<ProgramTemplate> ProgramTemplate { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}