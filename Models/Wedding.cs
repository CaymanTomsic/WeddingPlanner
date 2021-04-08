using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}
        
        [Required]
        [MinLength(2)]
        public string WeddingOne { get; set; }
        
        [Required]
        [MinLength(2)]
        public string WeddingTwo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int CreatorId {get; set;}

        public User Creator{get; set;}

        public List<WeddingGuest> Guests {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}