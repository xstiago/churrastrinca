using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurrasTrinca.Models
{
    public class ParticipantModel
    {
        public int ParticipantID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Valor Contribuição")]
        public decimal ContributionValue { get; set; }

        [Display(Name = "Pago")]
        public bool IsPaid { get; set; }

        [Display(Name = "Com Bebida")]
        public bool WithDrink { get; set; }

        [Display(Name = "Observações")]
        public string Comments { get; set; }
    }
}