using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Tjuv_O_Polis
{
    class Program
    {
        static int rånadeMedborgare = 0;
        static int gripnaTjuvar = 0;

        static int antalPoliser = 10;
        static int antalTjuvar = 20;
        static int antalMedborgare = 30;


        public static void Main(string[] args)
        {

            List<People> city = CityMetoder.FillCityWithPeople(antalPoliser, antalTjuvar, antalMedborgare);

            while(true)
            {
                string[,] arrayCity = new string[25,100];
                string Message = "";
                for (int h = 0; h < 25; h++)
                {
                    Console.Write($"{arrayCity[h, 0]}");

                    for (int w = 0; w < 100; w++)
                    {
                        Console.Write($"{arrayCity[0, w]}");

                        foreach (People p in city)
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
                                        

                }
                Console.WriteLine(Message);
                Console.WriteLine("\nAntal rånade medborgare : " + rånadeMedborgare);
                Console.WriteLine("Antal gripna tjuvar     : " + gripnaTjuvar);


                Thread.Sleep(2000);
                Console.Clear();
                Message = "";
            }      
        }
        class CityMetoder
        {
            public static int StartX()
            {
                Random rnd = new Random();
                int startx = rnd.Next(0, 25);

                return startx;
            }
            public static int StartY()
            {
                Random rnd = new Random();
                int startY = rnd.Next(0, 100);

                return startY;
            }
            public static int MoveX()
            {
                int movementX = 0;
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
            public static int MoveY()
            {
                int movementY = 0;
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

            public static List<People> FillCityWithPeople(int antalPoliser, int antalTjuvar, int antalMedborgare)
            {
                List<People> city = new List<People>();
                for (int i = 1; i <= antalPoliser; i++)
                {
                    People p = new Polis();
                    p.CurrentX = CityMetoder.StartX();
                    p.CurrentY = CityMetoder.StartY();
                    p.MovementX = CityMetoder.MoveX();
                    p.MovementY = CityMetoder.MoveY();
                    city.Add(p);
                }

                for (int i = 1; i <= antalTjuvar; i++)
                {
                    People t = new Tjuv();
                    t.CurrentX = CityMetoder.StartX();
                    t.CurrentY = CityMetoder.StartY();
                    t.MovementX = CityMetoder.MoveX();
                    t.MovementY = CityMetoder.MoveY();
                    city.Add(t);
                }

                for (int i = 1; i <= antalMedborgare; i++)
                {
                    People c = new Medborgare();
                    c.CurrentX = CityMetoder.StartX();
                    c.CurrentY = CityMetoder.StartY();
                    c.MovementX = CityMetoder.MoveX();
                    c.MovementY = CityMetoder.MoveY();
                    city.Add(c);
                }

                return city;
            }                     
        }
    }

    

    public class People
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
