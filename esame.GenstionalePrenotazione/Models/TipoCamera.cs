using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace esame.GenstionalePrenotazione.Models
{
    public class TipoCamera
    {
        public int IdTipoCamera { get; set; }
        public string Tipologia { get; set; }
        public decimal Prezzo { get; set; }
    }
}