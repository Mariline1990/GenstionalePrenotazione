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
    public class CameraController : Controller
    {
        // GET: Camera
        public ActionResult Index()
        {
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



                cmd.CommandText = "SELECT * FROM Camera";
                SqlDataReader reader = cmd.ExecuteReader();
                Response.Write(reader);

                List<Camera> Tipi = new List<Camera>();

                while (reader.Read())
                {

                    Camera Tipo = new Camera
                    {



                        IdCamera = Convert.ToInt16(reader["IdCamera"]),
                        Numero = reader["Numero"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                      


                    };

                    Tipi.Add(Tipo);
                }

                return View(Tipi);
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
