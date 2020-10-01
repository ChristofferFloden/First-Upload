using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Tjuv_O_Polis
{
    class Program
    {
        // Först några variabler som kommer användas för att visa antal rånade/gripna. 
        // Sedan några fler som bestämmer hur många av olika "People" som senare kommer befolka "staden". 

        static int rånadeMedborgare = 0;
        static int gripnaTjuvar = 0;

        static int antalPoliser = 10;
        static int antalTjuvar = 20;
        static int antalMedborgare = 30;


        public static void Main(string[] args)
        {
            // Skapar en lista staden med en metod som tar in de tidigare definierade antalet People av olika slag.
            List<People> city = CityMetoder.FillCityWithPeople(antalPoliser, antalTjuvar, antalMedborgare);

            while(true)                                     // Loopen som innehåller hela "spelet".
            {

                string Message = ""; // Tänkt att användas för de olika "meddelanden" som dykar upp vid "händelser", men kommer nog slopas.

                string[,] arrayCity = new string[25,100];  // En 2d-array som är tänkt att använda som "spelbräde"


                for (int h = 0; h < 25; h++) // Bygger den vertikala delen av brädet.
                {
                    Console.Write($"{arrayCity[h, 0]}");

                    for (int w = 0; w < 100; w++) // Bygger den horisontella delen av brädet.
                    {
                        Console.Write($"{arrayCity[0, w]}");
                    }
                }

                foreach (People p in city) // Tänkt att se vad som händer när olika People möter varandra, men än så länge... blaha
                {


                    //if ((((Polis)p).CurrentX) == (((Tjuv)p).CurrentX) && (((Polis)p).CurrentY) == (((Tjuv)p).CurrentY))
                    //{
                    //    Console.Write("X");
                    //    gripnaTjuvar++;
                    //}
                    //else if ((((Medborgare)p).CurrentX) == (((Tjuv)p).CurrentX) && (((Medborgare)p).CurrentY) == (((Tjuv)p).CurrentY))
                    //{
                    //    Console.Write("X");
                    //    rånadeMedborgare++;
                    //}


                    // Följande delar skall se till att ingen faller av brädet utan fortsätter på "andra sidan"

                    if (p.CurrentY < 0)
                    {
                        p.CurrentY = 25;
                    }
                    else if (p.CurrentY > 25)
                    {
                        p.CurrentY = 0;
                    }
                    else if (p.CurrentX < 0)
                    {
                        p.CurrentX = 100;
                    }
                    else if (p.CurrentX > 100)
                    {
                        p.CurrentX = 0;
                    }

                }

                // Här under brädet skall olika meddelanden skrivas ut mellan ronderna.
                Console.WriteLine(Message);
                Console.WriteLine("\nAntal rånade medborgare : " + rånadeMedborgare);
                Console.WriteLine("Antal gripna tjuvar     : " + gripnaTjuvar);


                Thread.Sleep(2000);
                Console.Clear();
                Message = "";
            }      
        }
    }
}
