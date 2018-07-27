﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class RegisterForEvent
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string EventName { get; set; }
        public string Email { get; set; }
    }
}