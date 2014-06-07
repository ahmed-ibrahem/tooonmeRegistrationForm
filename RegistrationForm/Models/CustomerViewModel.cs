using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationForm.Models
{
    public class CustomerViewModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [MinLength(12)]
        public string MobileNumber { get; set; }
        [MinLength(7)]
        public string PhoneNumber { get; set; }


        [StringLength(100)]
        public string Address { get; set; }
        public DateTime birthDate { get; set; }
    }
}