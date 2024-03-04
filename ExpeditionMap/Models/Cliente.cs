using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpeditionMap.Models
{
    public class Cliente
    {
        public string CodiceFiscale { get; set; }
        public string PartitaIva {  get; set; }
        public string Email { get; set; }
        public int RecapitoTel {  get; set; }

        [Required(ErrorMessage = "Indirizzo Obbligatorio")]
        public string Indirizzo { get; set; }

        [Required(ErrorMessage = "Nominativo Obbligatorio")]
        public string NominativoCliente { get; set; }
    }
}