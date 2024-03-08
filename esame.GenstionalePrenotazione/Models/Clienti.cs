using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace esame.GenstionalePrenotazione.Models
{
    public class Clienti
    {
        public int IdCliente { get; set; }
        public string CodFisc { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int Cellulare { get; set; }
        public Clienti()
        {

        }

        public Clienti  (int idCliente, string codFisc, string cognome, string nome, string citta, string provincia, string email, int telefono, int cellulare)
        {
            IdCliente = idCliente;
            CodFisc = codFisc;
            Cognome = cognome;
            Nome = nome;
            Citta = citta;
            Provincia = provincia;
            Email = email;
            Telefono = telefono;
            Cellulare = cellulare;
        }
       
    }
}
      