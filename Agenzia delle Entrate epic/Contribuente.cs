using System;

namespace Agenzia_delle_Entrate_epic
{
    internal class Contribuente
    {
        private string nome { get; set; }
        private string cognome { get; set; }
        private DateTime dataNascita { get; set; }
        private string codiceFiscale { get; set; }
        private string sesso { get; set; }
        private string comuneResidenza { get; set; }
        private double reddito { get; set; }
        public double imposta { get; set; }
        public double redditoAnnualeNetto { get; set; }

        public string GetName()
        {
            return nome;
        }

        public string GetCognome()
        {
            return cognome;
        }

        public DateTime GetDataNascita()
        {
            return dataNascita;
        }

        public string GetSesso()
        {
            return sesso;
        }

        public string GetResidenza()
        {
            return comuneResidenza;
        }

        public string GetCodiceFiscale()
        {
            return codiceFiscale;
        }

        public double GetReddito()
        {
            return reddito;
        }

        // Creo il costruttore che userò nella classe delle agenzia delle entrate.
        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, string sesso, string comuneResidenza, double reddito)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.dataNascita = dataNascita;
            this.codiceFiscale = codiceFiscale;
            this.sesso = sesso;
            this.comuneResidenza = comuneResidenza;
            this.reddito = reddito;
        }

        // Creo il metodo del calcolo dell'aliquota mediante l'uso di uno switch.
        // Mi ritornerà una cifra numerica ossia il redditoAnnualeNetto.
        public double CalcolaAliquota()
        {
            switch (reddito)
            {
                case var reddito when reddito >= 0 && reddito <= 15000:
                    imposta = reddito * 23 / 100;
                    break;
                case var reddito when reddito <= 28000:
                    imposta = 3450 + ((reddito - 15000) * 27 / 100);
                    break;
                case var reddito when reddito <= 55000:
                    imposta = 6960 + ((reddito - 28000) * 38 / 100);
                    break;
                case var reddito when reddito <= 75000:
                    imposta = 17220 + ((reddito - 55000) * 41 / 100);
                    break;
                case var reddito when reddito > 75000:
                    imposta = 25420 + ((reddito - 75900) * 43 / 100);
                    break;
                default:
                    Console.WriteLine("Reddito annuale non inserito. Riprova ad inserire");
                    Console.WriteLine("il tuo reddito annuale per effettuare il calcolo.");
                    SportelloAgenzia.Menu();
                    break;
            }
            return redditoAnnualeNetto = reddito - imposta;
        }
    }
}
