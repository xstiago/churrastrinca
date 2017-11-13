using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurrasTrinca.Entities
{
    public class Barbecue
    {
        public int BarbecueID { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        
        [MaxLength(500)]
        public string Comments { get; set; }

        [Required]
        public decimal WithDrink { get; set; }

        [Required]
        public decimal WithoutDrink { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }

        public Barbecue()
        {
            this.Participants = new HashSet<Participant>();
        }
    }
}
