using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace StoreFrontLAB.Models
{
    public class ContactViewModel
    {

        [Required(ErrorMessage = "* Full Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Email is required")]
        [EmailAddress(ErrorMessage = "* Please enter a valid email")]
        public string Email { get; set; }
        public int Number { get; set; }
        [Required(ErrorMessage = "* Message is required")]
        public string Message { get; set; }

    }
}