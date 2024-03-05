using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpeditionMap.Models
{
    public class Utente
    {
        [Key]
        public int IdUtente { get; set; }

        [Required(ErrorMessage = "Username Obbligatorio")]
        [StringLength(10, ErrorMessage = "Il nome utente deve essere di massimo 30 caratteri")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Obbligatorio")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "La password deve essere di massimo 30 caratteri")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ruolo utente Obbligatorio")]
        [StringLength(10, ErrorMessage ="Il ruolo deve essere di massimo 10 caratteri")]
        public string Ruolo { get; set; }

    }
}