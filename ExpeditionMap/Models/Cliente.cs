using System;
using System.Collections.Generic;
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
        public string Indirizzo { get; set; }
        public string NominativoCliente { get; set; }
    }
}