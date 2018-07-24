using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class EventList
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hours { get; set; }
        public string Cost { get; set; }
        public string address { get; set; }

    }
}