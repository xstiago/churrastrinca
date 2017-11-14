using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChurrasTrinca.Models
{
    public class BarbecueModel
    {
        public int BarbecueID { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [MaxLength(200)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [MaxLength(500)]
        [Display(Name = "Observações")]
        public string Comments { get; set; }

        [Display(Name = "Total Arrecadado")]
        public decimal TotalCollected { get; set; }

        [Display(Name = "Valor Bebida")]
        public decimal WithDrink { get; set; }

        [Display(Name = "Valor sem Bebida")]
        public decimal WithoutDrink { get; set; }

        [Display(Name = "Número de participantes")]
        public int ParticipantsNumber { get; set; }

        [Display(Name = "Valor já pago")]
        public decimal AmountAlreadyPaid { get; set; }

        [Display(Name = "Total de bebuns")]
        public int TotalDrunker { get; set; }

        [Display(Name = "Total de saudáveis")]
        public int TotalNotDrunker { get; set; }

        [Display(Name = "Participantes")]
        public int TotalParticipants { get; set; }

        public ICollection<ParticipantModel> Participants { get; set; }

        public BarbecueModel()
        {
            this.Participants = new List<ParticipantModel>();
        }
    }
}