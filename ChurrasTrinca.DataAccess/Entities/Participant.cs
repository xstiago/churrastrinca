using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurrasTrinca.DataAccess.Entities
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal ContributionValue { get; set; }

        [Required]
        public bool IsPaid { get; set; }

        [Required]
        public bool WithDrink { get; set; }

        [MaxLength(200)]
        public string Comments { get; set; }
    }
}
