using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace esame.GenstionalePrenotazione.Models
{
    public class Prenotazioni
    {
        public int IdPrenotazione { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
      
        public DateTime DataPrenotazione { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCheckIn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCheckOut { get; set; }
        public decimal Anticipo { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public string TipoPensione { get; set; }
        public int Prezzo { get; set; }
        public int Id_cliente{ get; set; }
        public int Id_camera { get; set; }
        public int Id_servizio{ get; set; }

        public Prenotazioni()
        {
            // Default constructor
        }
        public Prenotazioni(int idPrenotazione, DateTime dataPrenotazione, DateTime dataCheckIn, DateTime dataCheckOut, decimal anticipo, string nome, string cognome, string tipoPensione, int prezzo, int id_cliente, int id_camera, int id_servizio)
        {
            IdPrenotazione = idPrenotazione;
            DataPrenotazione = dataPrenotazione;
            DataCheckIn = dataCheckIn;
            DataCheckOut = dataCheckOut;
            Anticipo = anticipo;
            Nome = nome;
            Cognome = cognome;
            TipoPensione = tipoPensione;
            Prezzo = prezzo;
            Id_cliente = id_cliente;
            Id_camera = id_camera;
            Id_servizio = id_servizio;
        }


    }
}
