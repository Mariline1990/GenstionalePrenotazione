using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace esame.GenstionalePrenotazione.Models
{
    public class Checkout
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
      
        public string Servizio { get; set; }
        public decimal Costo  { get; set; }
        public  string Camera { get; set; }

        public Checkout()
        {
            // Default constructor
        }
        public Checkout(string nome, string cognome, string servizio, decimal costo, string camera)
        {
            Nome = nome;
            Cognome = cognome;
            Servizio = servizio;
            Costo = costo;
            Camera = camera;
        }
    }
}