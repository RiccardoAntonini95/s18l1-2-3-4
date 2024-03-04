using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpeditionMap.Models
{
    public class StatoSpedizione
    {
        public int IdSpedizione { get; set; }
        public string Stato {  get; set; }
        public string Descrizione { get; set; }
        public DateTime DataOraSpedizione { get; set; }
    }
}