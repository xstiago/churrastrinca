using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurrasTrinca.DataAccess.Entities
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

        [NotMapped]
        public decimal TotalCollected { get; set; }

        [Required]
        public decimal WithDrink { get; set; }

        [Required]
        public decimal WithoutDrink { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
