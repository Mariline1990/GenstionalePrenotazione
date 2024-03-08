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
    public class checkoutController : Controller
    {
        // GET: checkout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Prenotazione"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();



                cmd.CommandText = "SELECT Prenotazioni.NOME, Prenotazioni.COGNOME, Camera.Tipo,      SUM(Prenotazioni.PREZZO + Servizio.Prezzo) AS Totale FROM Prenotazioni " +
                    "INNER JOIN Camera ON Camera.idCamera = Prenotazioni.fk_idCamera INNER JOIN Servizio ON Servizio.idServizio = Prenotazioni.fk_idServizio GROUP BY NOME, COGNOME, TIPO;";
                SqlDataReader reader = cmd.ExecuteReader();
                Response.Write(reader);

                List<Checkout> uscite = new List<Checkout>();

                while (reader.Read())
                {

                    Checkout uscita = new Checkout
                    {


                        Nome = reader["NOME"].ToString(),
                        Cognome = reader["COGNOME"].ToString(),
                        Servizio = reader["TIPO"].ToString(),
                        Costo = Convert.ToInt32(reader["TOTALE"])


                    };

                    uscite.Add(uscita);
                }

                return View(uscite);
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
        }
    }
}