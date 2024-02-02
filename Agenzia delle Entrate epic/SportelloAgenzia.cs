using System;

namespace Agenzia_delle_Entrate_epic
{
    internal static class SportelloAgenzia
    {
        // Creao il metodo Menu().
        // Mi renderizza a schermo il "logo" dell'agenzia dell' entrate. Subito dopo mi chiede se voglio proseguire.
        // C'è un controlle mediante do while sulla risposta. Finchè i caratteri inseriti in input non corrispondono a
        // "y" o "n" non esce dal loop, ci dice "Input non valido" e richiedere la riassegnazione della scelta.
        // Uscito dal loop se la scelta è "n" ci saluta e il programma termina, altrimenti parte la Registrazione().
        public static void Menu()
        {
            Console.WriteLine(
                "=======================================\n" +
                "A G E N Z I A  D E L L '  E N T R A T E\n" +
                "=======================================\n");
            string scelta;
            do
            {
                Console.WriteLine("Benvenuto allo sportello dell'agenzia, ci devi qualcosa ;). Vuoi proseguire (y/n) ");
                scelta = Console.ReadLine();
                if (scelta != "y" && scelta != "n")
                {
                    Console.WriteLine("Input non valido.");
                }
            }
            while (scelta != "y" && scelta != "n");

            if (scelta == "n")
            {
                Console.WriteLine("Prima o poi saldiamo il conto :)");
                Console.ReadLine();
            }
            else
            {
                CompilaIlForm();
            }
        }

        // CompilaIlForm() dichiara delle variabili che vengono assegnate dall'utente in input, DOPO i controlli del caso.
        // Dopo aver popolato tutte le variabili con successo instanzio un oggetto utente dalla classe Contribuente tremite
        // un costruttore costum che mi sono creato nella classe.
        // Una volta instanziato l'oggetto chiameremo il metodo CalcoloRedditoNetto();
        public static void CompilaIlForm()
        {
            // Dichiaro la variabile di tipo stringa nome  e tramite do while gli faccio un controllo per evitare che si possa
            // accedere alla fase successiva senza inserire un nome
            string nome;
            do
            {
                Console.WriteLine("Inserisci il tuo nome: ");
                nome = Console.ReadLine();
                if (nome == "")
                {
                    Console.WriteLine("Non hai inserito nessun nome!");
                }
            }
            while (nome == "");

            // Qui faccio la stessa cosa che ho fatto sopra
            string cognome;
            do
            {

                Console.WriteLine("Inserisciil tuo cognome: ");
                cognome = Console.ReadLine();
                if (cognome == "")
                {
                    Console.WriteLine("Non hai inserito nessun cognome!");
                }
            }
            while (cognome == "");

            Console.WriteLine("Inserisci la tua data di nascita es: gg/mm/aaaa");
            DateTime dataNascita;
            // Questo controllo serve per verificare il formato corretto della data
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascita))
            {
                Console.WriteLine("Data non valida.");
            }

            string codiceFiscale;
            // Controllo per la validità del codice fiscale
            do
            {
                Console.WriteLine("Inserisci il tuo codice fiscale: ");
                codiceFiscale = Console.ReadLine();
                if (codiceFiscale.Length != 16)
                {
                    Console.WriteLine("Codice fiscale non valido. Il C.F. è composto da 16 caratteri alfa numerici.");
                }

            }

            while (codiceFiscale.Length != 16);

            string sesso;
            // Controllo dei caratteri inseriti per dichiarare il sesso
            do
            {

                Console.WriteLine("Inserisci il tuo sesso: M/F");
                sesso = Console.ReadLine().ToLower();
                if (sesso != "m" && sesso != "f")
                {
                    Console.WriteLine("Input non valido: scegli  'm' o 'f' ");
                }
            }
            while (sesso != "m" && sesso != "f");

            string comuneResidenza;
            // Controllo per evitare il non riempimento del campo del comune di residenza
            do
            {
                Console.WriteLine("Inserisci il tuo comune di residenza: ");
                comuneResidenza = Console.ReadLine();
                if (comuneResidenza == "")
                {
                    Console.WriteLine("Non hai inserito nessun comune di residenza");
                }

            } while (comuneResidenza == "");
            Console.WriteLine("Inserisci il tuo reddito annuale: ");
            double reddito;
            while (!double.TryParse(Console.ReadLine(), out reddito))
            {
                Console.WriteLine("Input non valido, inserisci un importo numerico.");
            }
            // instazio l'oggetto utente dalla classe Contribuente e inizializzo i valori passando tutte le variabili raccolte dagli input.
            Contribuente utente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, reddito);
            Console.WriteLine(
                "==============================================\n" +
                "R E G I S T R A Z I O N E  E F F E T T U A T A\n" +
                "==============================================\n");
            // metodo per calcolare il reddito netto e gli passo l'utente instanziato precedentemente
            CalcoloRedditoNetto(utente);

        }

        // Metodo per calcolare il reddito netto a cui passo come parametro un parametro di tipo Contribuente
        public static void CalcoloRedditoNetto(Contribuente utente)
        {
            // Controlli per la scelta
            string sceltaCalcolo;
            do
            {
                Console.WriteLine("Scopri quanti soldi ti restano dopo che ci prendiamo quello che ci spetta! \nDigita (y/n)");
                sceltaCalcolo = Console.ReadLine();
                if (sceltaCalcolo != "y" && sceltaCalcolo != "n")
                {
                    Console.WriteLine("Input non valido.");
                }
            } while (sceltaCalcolo != "y" && sceltaCalcolo != "n");

            if (sceltaCalcolo == "y")
            {
                utente.CalcolaAliquota();

            }
            else
            {
                Console.WriteLine("Quindi non vuoi sapere quanto ci prenderemo, SI perché i soldi ce li prenderemo lo stesso.");
            }
            Console.WriteLine(
                "====================================================================\n" +
                "S C O P R I  A  Q U A N T O  A M M O N T A  L '  E S T O R S I O N E\n" +
                "====================================================================\n" +
                $"Contribuente: {utente.GetName()} {utente.GetCognome()} \nSesso: {utente.GetSesso()}\n" +
                // Qui uso l'operatore ternario per scegliere se usare Nato o Nata
                $"{(utente.GetSesso() == "m" ? "Nato" : "Nata")}: {utente.GetDataNascita().ToString("dd/MM/yyyy")}\n" +
                $"Residente in: {utente.GetResidenza()}\n" +
                $"Codice Fiscale: {utente.GetCodiceFiscale()}\n" +
                $"Reddito lordo dichairato: {utente.GetReddito()}\n" +
                $"Reddito netto: {utente.redditoAnnualeNetto}\n" +
                $"Imposta da versare: {utente.imposta}\n");
            Console.ReadLine();


        }

    }
}
