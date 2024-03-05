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
    public class ClienteController : Controller
    {
        [Authorize]
        public ActionResult AggiungiCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AggiungiCliente(Cliente nuovoCliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpeditionMapDb"].ToString();
            var conn = new SqlConnection(connectionString);
            if(ModelState.IsValid)
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand(@"INSERT INTO Clienti
                     (CodiceFiscale, PartitaIva, Email, RecapitoTel, Indirizzo, NominativoCliente) VALUES 
                     (@codiceFiscale, @partitaIva, @email, @recapitoTel, @indirizzo, @nominativoCliente)", conn);
                    command.Parameters.AddWithValue("@codiceFiscale", nuovoCliente.CodiceFiscale);
                    command.Parameters.AddWithValue("@partitaIva", nuovoCliente.PartitaIva);
                    command.Parameters.AddWithValue("@email", nuovoCliente.Email);
                    command.Parameters.AddWithValue("@recapitoTel", nuovoCliente.RecapitoTel);
                    command.Parameters.AddWithValue("@indirizzo", nuovoCliente.Indirizzo);
                    command.Parameters.AddWithValue("@nominativoCliente", nuovoCliente.NominativoCliente);
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