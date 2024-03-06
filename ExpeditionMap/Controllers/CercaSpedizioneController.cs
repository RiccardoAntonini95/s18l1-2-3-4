using ExpeditionMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

namespace ExpeditionMap.Controllers
{
    public class CercaSpedizioneController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string codiceF, string partitaI)
        {
            return RedirectToAction("RisultatoTracciamento", new { CodiceFiscale = codiceF, PartitaIva = partitaI });
        }
        public ActionResult RisultatoTracciamento(string CodiceFiscale, string PartitaIva)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpeditionMapDb"].ToString();
            var conn = new SqlConnection(connectionString);
            List<StatoSpedizione> listaRicerca = new List<StatoSpedizione>();
            conn.Open();
            var commandList = new SqlCommand("SELECT s.IdSpedizione, Stato, Descrizione, DataOraSpedizione FROM StatoSpedizioni AS s JOIN Spedizioni AS sp ON s.IdSpedizione = sp.IdSpedizione JOIN Clienti AS c ON sp.NominativoDest = c.IdCliente WHERE CodiceFiscale = @codiceFiscale OR PartitaIva = @partitaIva ", conn);
            commandList.Parameters.AddWithValue("@codiceFiscale", CodiceFiscale);
            commandList.Parameters.AddWithValue("@partitaIva", PartitaIva);
            var readerList = commandList.ExecuteReader();

            if (readerList.HasRows) //recupera lista nominativi per il form spedizioni
            {
                while (readerList.Read())
                {
                    var statoSpedizione = new StatoSpedizione()
                    {
                        IdSpedizione = (int)readerList["IdSpedizione"],
                        Stato = (string)readerList["Stato"],
                        Descrizione = (string)readerList["Descrizione"],
                        DataOraSpedizione = (DateTime)readerList["DataOraSpedizione"]
                    };
                    listaRicerca.Add(statoSpedizione);
                    ViewBag.listaRicerca = listaRicerca;
                }
                conn.Close();
            }
            return View();
        }
    }
}