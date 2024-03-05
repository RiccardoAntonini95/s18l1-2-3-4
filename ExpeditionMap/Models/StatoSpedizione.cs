using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpeditionMap.Models
{
    public class StatoSpedizione
    {
        [Key]
        public int IdStatoSped { get; set; }

        [Required(ErrorMessage = "Id Spedizione Obbligatorio")]
        public int IdSpedizione { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Il valore inserito per lo stato non è valido")]
        [Required(ErrorMessage = "Stato spedizione Obbligatorio")]
        public string Stato {  get; set; }

        [StringLength(255, ErrorMessage = "La descrizione inserita è troppo lunga")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Data e ora Obbligatorie")]
        public DateTime DataOraSpedizione { get; set; }
    }
}