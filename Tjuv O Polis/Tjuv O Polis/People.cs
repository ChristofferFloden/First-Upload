using System;
using System.Collections.Generic;
using System.Text;

namespace Tjuv_O_Polis
{
    public class People  // Bas-klassen med alla egenskaper och sedan en indelning av de olika sub-klasserna.
    {
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int MovementX { get; set; }
        public int MovementY { get; set; }

        public virtual void EachMove()
        {
            Console.Write(" ");
        }


    }
    public class Polis : People
    {
        public override void EachMove()
        {
            Console.WriteLine("P");
        }
    }
    public class Tjuv : People
    {
        public override void EachMove()
        {
            Console.WriteLine("T");
        }
    }
    public class Medborgare : People
    {
        public override void EachMove()
        {
            Console.WriteLine("M");
        }
    }
}
