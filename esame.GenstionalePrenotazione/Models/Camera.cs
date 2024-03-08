using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace esame.GenstionalePrenotazione.Models
{
    public class Camera
    {

        public int IdCamera { get; set; }
        public string Numero { get; set; }      
        public string Tipo { get; set; }
  


        public Camera()
        {

        }
            
        public Camera(int idCamera, string numero, string tipo)
        {
            IdCamera = idCamera;
            Numero = numero;
            Tipo = tipo;
          
        }

    }
}