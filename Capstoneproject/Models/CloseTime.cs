using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class CloseTime
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Closing Time")]
        public string Start { get; set; }
    }
}