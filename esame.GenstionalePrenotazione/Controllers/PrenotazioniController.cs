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
    public class PrenotazioniController : Controller
    {
        // GET: Prenotazioni
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Prenotazioni model)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Prenotazione"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try

            {

                string query = "INSERT INTO Prenotazioni (DATAP, DATA_IN , DATA_OUT, ANTICIPO ,NOME , COGNOME, TIPO_PENSIONE, PREZZO, fk_IdCliente, fk_IdCamera, fk_IdServizio) VALUES ( @dataP, @DataIn, @DataOut,@Anticipo, @Nome,@Cognome,  @pensione, @Prezzo, @idCliente, @idCamera, @idServizio)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("dataP",model.DataPrenotazione);
                cmd.Parameters.AddWithValue("DataIn", model.DataCheckIn);
                    cmd.Parameters.AddWithValue("DataOut", model.DataCheckOut);
                cmd.Parameters.AddWithValue("Anticipo", model.Anticipo);
                cmd.Parameters.AddWithValue("Nome", model.Nome);
                    cmd.Parameters.AddWithValue("Cognome", model.Cognome);
                cmd.Parameters.AddWithValue("Pensione", model.TipoPensione);
                cmd.Parameters.AddWithValue("Prezzo", model.Prezzo);
                cmd.Parameters.AddWithValue("idCliente", model.Id_cliente);
                cmd.Parameters.AddWithValue("idCamera", model.Id_camera);
                cmd.Parameters.AddWithValue("idServizio", model.Id_servizio);
                    
                



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



        [HttpGet]
        public ActionResult List()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Prenotazione"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();



                cmd.CommandText = "SELECT * FROM Prenotazioni";
                SqlDataReader reader = cmd.ExecuteReader();
                Response.Write(reader);

                List<Prenotazioni> Prenotazione = new List<Prenotazioni>();

                while (reader.Read())
                {

                    Prenotazioni nuovaPrenotazione = new Prenotazioni           
                    {



                        IdPrenotazione = Convert.ToInt16(reader["IdPrenotazione"]),
                        DataPrenotazione = Convert.ToDateTime(reader["DATAP"]),
                        DataCheckIn = Convert.ToDateTime(reader["DATA_IN"]),
                        DataCheckOut = Convert.ToDateTime(reader["DATA_OUT"]),
                        Anticipo = Convert.ToDecimal(reader["ANTICIPO"]),
                        Nome = reader["NOME"].ToString(),
                        Cognome = reader["COGNOME"].ToString(),
                        TipoPensione = reader["TIPO_PENSIONE"].ToString(),
                        Prezzo = Convert.ToInt16(reader["PREZZO"]),

                    };

                    Prenotazione.Add(nuovaPrenotazione);
                }

                return View(Prenotazione);
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
        public ActionResult Edit()
        {
            return View();
        }


      
    }

    }
