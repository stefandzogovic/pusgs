﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Usermame { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        //public Sex sex { get; set; }
        //public Role role { get; set; }
        //public List<Apartment> apartments { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
