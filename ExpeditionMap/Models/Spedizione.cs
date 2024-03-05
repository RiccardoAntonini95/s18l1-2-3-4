using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpeditionMap.Models
{
    public class Spedizione
    {
        [Key]
        public int IdSpedizione { get; set; }

        [Required(ErrorMessage = "Data Spedizione Obbligatoria")]
        public DateTime DataSpedizione { get; set; }

        [Required(ErrorMessage = "Peso spedizione Obbligatorio")]
        public int Peso { get; set; }

        [StringLength(50, ErrorMessage = "Città non valida, inserire una città di massimo 50 caratteri")]
        [Required(ErrorMessage = "Città Obbligatoria")]
        public string CittaDestinataria { get; set; }

        [StringLength(50, ErrorMessage = "Indirizzo non valido, inserire un indirizzo di massimo 50 caratteri")]
        [Required(ErrorMessage = "Indirizzo Obbligatorio")]
        public string IndirizzoDest {  get; set; }

        [Required(ErrorMessage = "Nominativo Obbligatorio")]
        public int NominativoDest {  get; set; }

        [Required(ErrorMessage = "Costo Obbligatorio")]
        public int CostoSpedizione { get; set; }

        [Required(ErrorMessage = "Data prevista Obbligatoria")]
        public DateTime DataConsegnaPrevista {  get; set; }

    }
}