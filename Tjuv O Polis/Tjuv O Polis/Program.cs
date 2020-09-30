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

                    foreach (People p in city) // Tänkt att se vad som händer när olika People möter varandra, men än så länge... blaha
                    {

                        if ((((Polis)p).CurrentX) == (((Tjuv)p).CurrentX) && (((Polis)p).CurrentY) == (((Tjuv)p).CurrentY))
                        {
                            Console.Write("X");
                            gripnaTjuvar++;
                        }
                        else if ((((Medborgare)p).CurrentX) == (((Tjuv)p).CurrentX) && (((Medborgare)p).CurrentY) == (((Tjuv)p).CurrentY))
                        {
                            Console.Write("X");
                            rånadeMedborgare++;
                        }


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
        class CityMetoder // Tänkt att innehålla metoder för händelser i staden, men just nu även innehåller annat och är inte klart.
        {
            public static int StartX()
            {
                Random rnd = new Random();
                int startx = rnd.Next(0, 100);

                return startx;
            }
            public static int StartY()
            {
                Random rnd = new Random();
                int startY = rnd.Next(0, 25);

                return startY;
            }
            public static int MoveX(int X)
            {
                int movementX = X;
                Random rnd = new Random();
                int move = rnd.Next(0, 3);
                if (move == 1)
                {
                    movementX = +1;
                }
                else if (move == 2)
                {
                    movementX = -1;
                }

                return movementX;
            }
            public static int MoveY(int Y)
            {
                int movementY = Y;
                Random rnd = new Random();
                int move = rnd.Next(0, 3);
                if (move == 1)
                {
                    movementY = +1;
                }
                else if (move == 2)
                {
                    movementY = -1;
                }

                return movementY;
            }

            public static List<People> FillCityWithPeople(int antalPoliser, int antalTjuvar, int antalMedborgare)  // Metoden som befolkar staden.
            {
                Random rnd = new Random();
                List<People> city = new List<People>();
                for (int i = 1; i <= antalPoliser; i++)
                {
                    People p = new Polis();
                    p.CurrentX = CityMetoder.StartX();
                    p.CurrentY = CityMetoder.StartY();
                    p.MovementX = CityMetoder.MoveX(p.CurrentX);
                    p.MovementY = CityMetoder.MoveY(p.CurrentY);
                    city.Add(p);
                }

                for (int i = 1; i <= antalTjuvar; i++)
                {
                    People t = new Tjuv();
                    t.CurrentX = CityMetoder.StartX();
                    t.CurrentY = CityMetoder.StartY();
                    t.MovementX = CityMetoder.MoveX(t.CurrentX);
                    t.MovementY = CityMetoder.MoveY(t.CurrentY);
                    city.Add(t);
                }

                for (int i = 1; i <= antalMedborgare; i++)
                {
                    People c = new Medborgare();
                    c.CurrentX = CityMetoder.StartX();
                    c.CurrentY = CityMetoder.StartY();
                    c.MovementX = CityMetoder.MoveX(c.CurrentX);
                    c.MovementY = CityMetoder.MoveY(c.CurrentY);
                    city.Add(c);
                }

                return city;
            }                     
        }
    }

    

    public class People  // Bas-klassen med alla egenskaper och sedan en indelning av de olika sub-klasserna.
    {
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int MovementX { get; set; }
        public int MovementY { get; set; }


    }
    public class Polis : People 
    {
    }
    public class Tjuv : People 
    {
    }
    public class Medborgare : People 
    {
    }
}
