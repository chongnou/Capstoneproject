using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}