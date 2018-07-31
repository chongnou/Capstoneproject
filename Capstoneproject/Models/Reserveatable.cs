using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class Reserveatable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RestaurantName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}