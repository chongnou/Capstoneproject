using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class Reserveviptable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarName { get; set; }
        public string PhoneNumber { get; set; }
        public string PartySize { get; set; }
        public string Email { get; set; }
    }
}