using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace esame.GenstionalePrenotazione.Models
{
    public class Gestionale
    {

        public int IdAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ruolo { get; set; }


    }
}