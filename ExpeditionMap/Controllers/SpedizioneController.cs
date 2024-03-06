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
    public class SpedizioneController : Controller
    {
        [Authorize]
        public ActionResult AggiungiSpedizione()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpeditionMapDb"].ToString();
            var conn = new SqlConnection(connectionString);
            List<Cliente> listaClienti = new List<Cliente>();
            conn.Open();
            var commandList = new SqlCommand("SELECT * FROM Clienti", conn);
            var readerList = commandList.ExecuteReader();

            if (readerList.HasRows) //recupera lista nominativi per il form spedizioni
            {
                while (readerList.Read())
                {
                    var cliente = new Cliente()
                    {
                        IdCliente = (int)readerList["IdCliente"],
                        CodiceFiscale = (string)readerList["CodiceFiscale"],
                        PartitaIva = (string)readerList["PartitaIva"],
                        Email = (string)readerList["Email"],
                        RecapitoTel = (int)readerList["RecapitoTel"],
                        Indirizzo = (string)readerList["Indirizzo"],
                        NominativoCliente = (string)readerList["NominativoCliente"]
                    };
                    listaClienti.Add(cliente);
                    ViewBag.listaClienti = listaClienti;
                }
                conn.Close();
            }
            return View();
        }

        [HttpPost]
        public ActionResult AggiungiSpedizione(Spedizione nuovaSpedizione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpeditionMapDb"].ToString();
            var conn = new SqlConnection(connectionString);
            if (ModelState.IsValid)
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand(@"INSERT INTO Spedizioni
                     (DataSpedizione, Peso, CittaDestinataria, IndirizzoDest, NominativoDest, CostoSpedizione, DataConsegnaPrevista) VALUES 
                     (@dataSpedizione, @peso, @cittaDestinataria, @indirizzoDest, @nominativoDest, @costoSpedizione, @dataConsegnaPrevista)", conn);
                    command.Parameters.AddWithValue("@dataSpedizione", nuovaSpedizione.DataSpedizione);
                    command.Parameters.AddWithValue("@peso", nuovaSpedizione.Peso);
                    command.Parameters.AddWithValue("@cittaDestinataria", nuovaSpedizione.CittaDestinataria);
                    command.Parameters.AddWithValue("@indirizzoDest", nuovaSpedizione.IndirizzoDest);
                    command.Parameters.AddWithValue("@nominativoDest", nuovaSpedizione.NominativoDest);
                    command.Parameters.AddWithValue("@costoSpedizione", nuovaSpedizione.CostoSpedizione);
                    command.Parameters.AddWithValue("@dataConsegnaPrevista", nuovaSpedizione.DataConsegnaPrevista);
                    var nRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
                finally { conn.Close(); }
                return RedirectToAction("Index", "Home"); //feedback riuscita
            }
            return View();

        }

        [Authorize]
        public ActionResult StatoSpedizione()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpeditionMapDb"].ToString();
            var conn = new SqlConnection(connectionString);
            List<Spedizione> listaSpedizioni = new List<Spedizione>();
            conn.Open();
            var commandList = new SqlCommand("SELECT * FROM Spedizioni", conn);
            var readerList = commandList.ExecuteReader();

            if (readerList.HasRows) //recupera lista nominativi per il form spedizioni
            {
                while (readerList.Read())
                {
                    var spedizione = new Spedizione()
                    {
                        IdSpedizione = (int)readerList["IdSpedizione"],
                        DataSpedizione = (DateTime)readerList["DataSpedizione"],
                        Peso = (int)readerList["Peso"],
                        CittaDestinataria = (string)readerList["CittaDestinataria"],
                        IndirizzoDest = (string) readerList["IndirizzoDest"],
                        NominativoDest = (int)readerList["NominativoDest"],
                        CostoSpedizione = (int)readerList["CostoSpedizione"],
                        DataConsegnaPrevista = (DateTime)readerList["DataConsegnaPrevista"]
                    };
                    listaSpedizioni.Add(spedizione);
                    ViewBag.listaSpedizioni = listaSpedizioni;
                }
                conn.Close();
            }
            return View();
        }

        [HttpPost]
        public ActionResult StatoSpedizione(StatoSpedizione nuovoStatoSpedizione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpeditionMapDb"].ToString();
            var conn = new SqlConnection(connectionString);
            if (ModelState.IsValid)
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand(@"INSERT INTO StatoSpedizioni
                     (IdSpedizione, Stato, Descrizione, DataOraSpedizione) VALUES 
                     (@idSpedizione, @stato, @descrizione, @dataOraSpedizione)", conn);
                    command.Parameters.AddWithValue("@idSpedizione", nuovoStatoSpedizione.IdSpedizione);
                    command.Parameters.AddWithValue("@stato", nuovoStatoSpedizione.Stato);
                    command.Parameters.AddWithValue("@descrizione", nuovoStatoSpedizione.Descrizione);
                    command.Parameters.AddWithValue("@dataOraSpedizione", nuovoStatoSpedizione.DataOraSpedizione);
                    var nRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
                finally { conn.Close(); }
                return RedirectToAction("Index", "Home");
            }
            return View();

            //ho predisposto il form per aggiornare lo stato spedizione, ora manda tutto con la post e con la query selezionerò 
            //tutto ciò che sta nella tabella con l'id spedizione relativo, ordinato dal più recente
        }
    }
}