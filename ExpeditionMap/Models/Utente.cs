using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpeditionMap.Models
{
    public class Utente
    {
        [Required(ErrorMessage = "Username Obbligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Obbligatorio")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Ruolo utente Obbligatorio")]
        public string Ruolo { get; set; }

    }
}