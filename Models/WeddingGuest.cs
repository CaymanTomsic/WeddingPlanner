using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class WeddingGuest
    {
        [Key]
        public int WeddingGuestId {get;set;}
        public int GuestId {get;set;}
        public User Guest {get;set;}
        public int WeddingId {get;set;}
        public Wedding Wedding {get;set;}
    }
}