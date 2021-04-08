using System;
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models
{
    public class LoginUser
    {
        [EmailAddress]
        [Required]
        public string LoginEmail { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string LoginPassword { get; set; }

    }
}
