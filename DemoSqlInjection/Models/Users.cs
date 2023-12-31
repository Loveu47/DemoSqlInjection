﻿using System.ComponentModel.DataAnnotations;

namespace DemoSqlInjection.Models
{
    public class Users
    {
        [Key]   
        
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Tasks> Tasks { get; set; }
    }
}
