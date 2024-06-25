using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Application.Models.Requests
{
    public class AuthenticationRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "invalid Email Address")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
