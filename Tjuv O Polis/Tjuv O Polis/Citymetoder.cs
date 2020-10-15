using System;
using System.Collections.Generic;
using System.Text;

namespace Tjuv_O_Polis
{
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
