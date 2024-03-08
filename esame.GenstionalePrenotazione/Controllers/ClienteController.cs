using esame.GenstionalePrenotazione.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace esame.GenstionalePrenotazione.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Clienti model)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Prenotazione"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
                
            {

                string query = "INSERT INTO Cllienti (CF, COGNOME , NOME, CITTA,PROVINCIA, EMAIL, TELEFONO, CELLULARE) VALUES ( @cf, @cognome, @nome,@citta, @email,@provincia,  @telefono, @cellulare)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cf", model.CodFisc);
                cmd.Parameters.AddWithValue("@cognome", model.Nome);
                cmd.Parameters.AddWithValue("@nome", model.Cognome);
                cmd.Parameters.AddWithValue("@citta", model.Citta);
                cmd.Parameters.AddWithValue("@email", model.Email);
                cmd.Parameters.AddWithValue("@provincia", model.Provincia);
                cmd.Parameters.AddWithValue("@telefono", model.Telefono);
                cmd.Parameters.AddWithValue("@cellulare", model.Cellulare);



                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Errore nella richiesta SQL");
                return View(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            TempData["Messaggio"] = "Cliente inserito correttamente";
            return View();

        }
    }
}