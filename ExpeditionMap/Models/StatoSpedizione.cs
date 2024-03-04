using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpeditionMap.Models
{
    public class StatoSpedizione
    {

        [Required(ErrorMessage = "Id Spedizione Obbligatorio")]
        public int IdSpedizione { get; set; }

        [Required(ErrorMessage = "Stato spedizione Obbligatorio")]
        public string Stato {  get; set; }
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Data e ora Obbligatorie")]
        public DateTime DataOraSpedizione { get; set; }
    }
}