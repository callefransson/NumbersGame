using System;
// Carl Fransson .NET23
namespace NumbersGame

{
    public class NumbersGame
    {

        public static void Main(string[] args)
        {
           
            int game;
            do // Skapat en do while loop med en switch-sats för att ta reda på vilken typ av svårhetsgrad användaren vill spela
            {
                    Console.WriteLine("Vänligen välj svårhetsgraden du vill spela! \nFör att välja svårhetsgrad lätt, vänligen tryck 1.\nOm du vill välja medium, vänligen tryck 2\nEller om ni vill " +
                        "spela på svår, tryck då 3.\nOm ni vill avsluta spelet tryck då 0");
                while (true)
                {
                    string convertString = Console.ReadLine(); // Lagrar användarens input i variabeln convertString
                    if (int.TryParse(convertString, out game)) // Om användaren försöker skriva något annat än ett heltal
                    {
                        break; // Loopen avslutas om användaren skriver in ett heltal
                    }
                    else // Om användaren skriver något annat än ett heltal skrivs det ut i consolen
                    {
                        Console.WriteLine("Vänligen välj bland alternativen");
                    }


                }

                switch (game) // Switch-satsen för de olika alternativen användaren får. Beroende på vilket alternativ användaren väljer körs de olika metoderna
                    {
                        case 1:
                            GuessNumberEasy();
                            break;

                        case 2:
                            GuessNumberMedium();
                            break;

                        case 3:
                            GuessNumberHard();
                            break;
                    }
                if (game == 0) // Om användaren skriver 0
                {
                    Console.WriteLine("Tack för att du spelade. Välkommen åter");
                }



            } while (game != 0); // Loopen körs så länge användaren inte skriver "0" 
                Console.WriteLine("Tryck på valfri tagnentknapp för att avsluta");
                Console.ReadKey();

            
        }
        static void GuessNumberEasy() // Metoden för svårhetsgrad lätt
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-20. Kan du gissa vilket? Du får fem försök.");
            Random random = new Random(); // Använder oss utav Random klassen för att generera ett slumptal från 1-20
            int randomGen = random.Next(1, 21);

            // De variablar som används i metoden
            int number;
            int attempts = 0;
            int maxAttempts = 5;
            bool guessCorrectly = false;
            while (attempts != maxAttempts) // Loopen körs så länge antal försök inte uppnår max antal försök
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number)) // Försöker konvertera inmatningen till ett heltal
                {

                    attempts++; // Antalet försök ökar med 1 för varje försök

                    if (number == randomGen) // Om användaren gissar rätt på slumptalet
                    {
                        Console.WriteLine("Grattis! Du lyckades träffa rätt på siffran! den rätta siffran var {0} och du lyckades på {1} försök!", randomGen, attempts);
                        break; // Avslutar loopen
                    }
                    else if (Math.Abs(number - randomGen) <= 2 && number < randomGen) // Vi beräknar ut absolutvärdet av skillnaden mellan användarens tal och det slumpade talet
                                                                                      // Om användaren är två siffror ifrån och dom är lägre än det slumpade talet 
                    {
                        Console.WriteLine("nu är du nära! Men du gissade för lågt..");
                    }
                    else if (Math.Abs(number - randomGen) <= 2 && number > randomGen) // Om användaren är två siffror ifrån och dom är högre än det slumpade talet
                    {
                        Console.WriteLine("nu är du nära! Men du gissade för högt..");
                    }
                    else if (number < randomGen) // Om användarens gissing är lägre än det slumpade talet
                    {
                        ToLowText(); // Anropar metoden som skriver ut att talet är lägre än det slumpade talet
                    }
                    else if (number > randomGen) // Om användarens gissing är högre än det slumpade talet
                    {
                        ToHighText(); // Anropar metoden som skriver ut att talet är högre än det slumpade talet
                    }

                    else if (attempts == maxAttempts) // Om användaren har gissat för många gånger
                    {
                        Console.WriteLine("Tyvärr så lyckades du inte denna gång. Talet vi sökte var {0}.", randomGen);
                    }
                }
                else
                {
                    Console.WriteLine("Vänligen skriv in ett giltigt heltal.");
                }
                if (!guessCorrectly && attempts == maxAttempts) // Om bool variabeln inte är sann och antal försök är lika med max antal försök
                {
                    Console.WriteLine("Tyvärr så lyckades du inte denna gång. Talet vi sökte var {0}.", randomGen); // Skriver ut vilket tal som var det slumpade talet
                }
            }
         

            TryAgain(); // Metoden för att spela igen

        }

        static void GuessNumberMedium() //  Metoden för svårhetsgrad medium
                                        // Denna metod är ungefär lika som den första bara att här har användaren endast 4 försök och måste gissa på ett slumptal mellan 1-50
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-50. Kan du gissa vilket? Du får fyra försök.");
            Random randomerare = new Random();
            int randomGen = randomerare.Next(1, 51);

            int number;
            int attempts = 0;
            int maxAttempts = 4;
            bool guessCorrectly = false;
            while (attempts < maxAttempts)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number)) // Försöker konvertera inmatningen till ett heltal
                {

                    attempts++; // Antalet försök ökar med 1 för varje försök

                    if (number == randomGen) // Om användaren gissar rätt på slumptalet
                    {
                        Console.WriteLine("Grattis! Du lyckades träffa rätt på siffran! den rätta siffran var {0} och du lyckades på {1} försök!", randomGen, attempts);
                        break; // Avslutar loopen
                    }
                    else if (Math.Abs(number - randomGen) <= 5 && number < randomGen) // Vi beräknar ut absolutvärdet av skillnaden mellan användarens tal och det slumpade talet
                                                                                      // Om användaren är 5 siffror ifrån och dom är lägre än det slumpade talet 
                    {
                        Console.WriteLine("nu är du nära! Men du gissade för lågt..");
                    }
                    else if (Math.Abs(number - randomGen) <= 5 && number > randomGen) // Om användaren är 5 siffror ifrån och dom är högre än det slumpade talet
                    {
                        Console.WriteLine("nu är du nära! Men du gissade för högt..");
                    }
                    else if (number < randomGen) // Om användarens gissing är lägre än det slumpade talet
                    {
                        ToLowText(); // Anropar metoden som skriver ut att talet är lägre än det slumpade talet
                    }
                    else if (number > randomGen) // Om användarens gissing är högre än det slumpade talet
                    {
                        ToHighText(); // Anropar metoden som skriver ut att talet är högre än det slumpade talet
                    }

                    else if (attempts == maxAttempts) // Om användaren har gissat för många gånger
                    {
                        Console.WriteLine("Tyvärr så lyckades du inte denna gång. Talet vi sökte var {0}.", randomGen);
                    }
                }
                else
                {
                    Console.WriteLine("Vänligen skriv in ett giltigt heltal.");
                }
                if (!guessCorrectly && attempts == maxAttempts) // Om bool variabeln inte är sann och antal försök är lika med max antal försök
                {
                    Console.WriteLine("Tyvärr så lyckades du inte denna gång. Talet vi sökte var {0}.", randomGen); // Skriver ut vilket tal som var det slumpade talet
                }
            }


            TryAgain();

        }

        static void GuessNumberHard() // Metoden för svårhetsgrad svår
                                      // Samma i denna metod fast här har användaren bara 3 försök och måste gissa på ett slumptal mellan 1-100
        {                                           
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-100. Kan du gissa vilket? Du får bara tre försök på dig att lista ut vad numret är.");
            Random random = new Random();
            int randomGen = random.Next(1, 101);

            int number;
            int attempts = 0;
            int maxAttempts = 3;
            bool guessCorrectly = false;
            while (attempts < maxAttempts)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number)) // Försöker konvertera inmatningen till ett heltal
                {

                    attempts++; // Antalet försök ökar med 1 för varje försök

                    if (number == randomGen) // Om användaren gissar rätt på slumptalet
                    {
                        Console.WriteLine("Grattis! Du lyckades träffa rätt på siffran! den rätta siffran var {0} och du lyckades på {1} försök!", randomGen, attempts);
                        break; // Avslutar loopen
                    }
                    else if (Math.Abs(number - randomGen) <= 10 && number < randomGen) // Vi beräknar ut absolutvärdet av skillnaden mellan användarens tal och det slumpade talet
                                                                                      // Om användaren är 10 siffror ifrån och dom är lägre än det slumpade talet 
                    {
                        Console.WriteLine("nu är du nära! Men du gissade för lågt..");
                    }
                    else if (Math.Abs(number - randomGen) <= 10 && number > randomGen) // Om användaren är 10 siffror ifrån och dom är högre än det slumpade talet
                    {
                        Console.WriteLine("nu är du nära! Men du gissade för högt..");
                    }
                    else if (number < randomGen) // Om användarens gissing är lägre än det slumpade talet
                    {
                        ToLowText(); // Anropar metoden som skriver ut att talet är lägre än det slumpade talet
                    }
                    else if (number > randomGen) // Om användarens gissing är högre än det slumpade talet
                    {
                        ToHighText(); // Anropar metoden som skriver ut att talet är högre än det slumpade talet
                    }

                    else if (attempts == maxAttempts) // Om användaren har gissat för många gånger
                    {
                        Console.WriteLine("Tyvärr så lyckades du inte denna gång. Talet vi sökte var {0}.", randomGen);
                    }
                }
                else
                {
                    Console.WriteLine("Vänligen skriv in ett giltigt heltal.");
                }
                if (!guessCorrectly && attempts == maxAttempts) // Om bool variabeln inte är sann och antal försök är lika med max antal försök
                {
                    Console.WriteLine("Tyvärr så lyckades du inte denna gång. Talet vi sökte var {0}.", randomGen); // Skriver ut vilket tal som var det slumpade talet
                }
            }

            TryAgain();

        }
        static void TryAgain() // Metoden för att spela igen
        {
            int again;
            do // Koden som ska köras i loopen
            {
                Console.WriteLine("Vill du försöka igen? tryck 1 för att starta om spelet. \nEller tryck 0 för att avsluta spelet");
                while (true)
                {
                    string convertString = Console.ReadLine();
                    if (int.TryParse(convertString, out again))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vänligen välj bland alternativen");
                    }


                }
                switch (again) // Switch-sats som kollar om användaren vill spela igen.
                {
                    case 1: // Om användaren skriver "1" så går användren tillbaka till huvudmenyn
                        Console.Clear();
                        break;
                    case 0: // Om användaren skriver "0" så avslutas spelet

                        Console.WriteLine("Tack för att du spelade!");
                        Environment.Exit(0); // Avslutar programmet
                        break;
                    default: // Om användaren skulle skriva något annat än "1" eller "0"
                        Console.WriteLine("Vänligen välj bland alternativen");
                        break;
                }
            } while (again != 1); // Loopen körs så länge användaren inte skriver "1"
        }
        static void ToHighText() // Metoden för att skriva ut olika varianter på för högt gissat
        {
            string[] toHighText = { "Tyvärr du gissade för högt", "Ajdå det var lite för högt gissat","Haha, där gissade du för högt" }; // Skapar en array med olika strängar
            
            Random random= new Random(); // Här används Random klassen för att få ut ett slumpmässigt index i arrayen 
                int randomIndex = random.Next(0, toHighText.Length); // Genererar ett slumpmässigt index mellan 0 och längden på arrayen
                Console.WriteLine(toHighText[randomIndex]); // Skriver ut det slumpmässiga meddelandet ut i konsolen
        }
        static void ToLowText() // Metoden för att skriva ut olika varianter på för lågt gissat
        {
            string[] toLowText = { "Tyvärr så gissade du för lågt", "Haha, du gissade för lågt", "Nej.. Det var för lågt" };
            Random random = new Random();
            int randomIndex = random.Next(0, toLowText.Length);
            Console.WriteLine(toLowText[randomIndex]);
        }

    }
}