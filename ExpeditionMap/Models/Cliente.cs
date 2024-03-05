using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpeditionMap.Models
{
    public class Cliente
    {
        [Key] 
        public int IdCliente { get; set; }

        [StringLength(16, MinimumLength = 16, ErrorMessage ="Il codice fiscale inserito non è valido")]
        public string CodiceFiscale { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "La partita iva inserita non è valida")]
        public string PartitaIva {  get; set; }

        [EmailAddress(ErrorMessage = "E-mail inserita non valida")]
        public string Email { get; set; }

       //[Range(1, 12, ErrorMessage = "Inserire un numero di telefono valido")]
        public int RecapitoTel {  get; set; }

        [StringLength(50, ErrorMessage = "Indirizzo inserito troppo lungo, inserire un indirizzo valido")]
        [Required(ErrorMessage = "Indirizzo Obbligatorio")]
        public string Indirizzo { get; set; }

        [StringLength(255, ErrorMessage = "Nominativo inserito troppo lungo, inserire un nominativo valido")]
        [Required(ErrorMessage = "Nominativo Obbligatorio")]
        public string NominativoCliente { get; set; }
    }
}