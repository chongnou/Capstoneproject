﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class Activities
    {
        [Key]
        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }


    }
}