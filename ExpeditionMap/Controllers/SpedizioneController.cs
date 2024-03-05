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
    }
}