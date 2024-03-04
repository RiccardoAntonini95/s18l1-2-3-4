using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpeditionMap.Models
{
    public class Spedizione
    {
        public DateTime DataSpedizione { get; set; }
        public int Peso { get; set; }
        public string CittaDestinataria { get; set; }
        public string IndirizzoDest {  get; set; }
        public int NominativoInt {  get; set; }
        public int CostoSpedizione { get; set; }
        public DateTime DataConsegnaPrevista {  get; set; }
    }
}