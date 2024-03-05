using ExpeditionMap.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExpeditionMap.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Utente utente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExpeditionMapDb"].ToString();
            var conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Utenti WHERE Username = @username AND Password = @password AND Ruolo = @ruolo", conn);
                command.Parameters.AddWithValue("@username", utente.Username);
                command.Parameters.AddWithValue("@password", utente.Password);
                command.Parameters.AddWithValue("@ruolo", utente.Ruolo);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    FormsAuthentication.SetAuthCookie(reader["IdUtente"].ToString(), true);
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("LoggedIn");
            }
            catch (Exception ex)
            {
                return RedirectToAction("LoggedIn");
            }
            finally
            { 
                conn.Close();
            }
        }

        [Authorize]
        public ActionResult LoggedIn()
        {
            var IdUtente = HttpContext.User.Identity.Name;
            ViewBag.IdUtente = IdUtente;
            return View();
        }

        [Authorize, HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            // sloggare l'utente
            FormsAuthentication.SignOut();

            // ridirezionarlo da qualche parte
            return RedirectToAction("Index", "Login");

        }
    }
}