using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class Profile
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Profile Name")]
        public string Name { get; set; }
        public string RegisteredEvents { get; set; }
    }
}