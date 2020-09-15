using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_6_1
{
    class Program
    {
        static void Main(string[] args)
        {

            var Forest = new List<AnimalsinForest>();
            bool nightTime = false;

            AnimalsinForest a1 = new AnimalsinForest();
            a1.Species = "Ormen";
            a1.IsNocturnal = false;
            a1.Activity = "jagar sitt byte med hjälp av sin tunga, som kan 'smaka' på luften";
            Forest.Add(a1);

            AnimalsinForest a2 = new AnimalsinForest();
            a2.Species = "Skorpionen";
            a2.IsNocturnal = true;
            a2.Activity = "springer runt o spelar 'Allan'";
            Forest.Add(a2);

            AnimalsinForest a3 = new AnimalsinForest();
            a3.Species = "Ugglan";
            a3.IsNocturnal = true;
            a3.Activity = "ser allt i mörkret och jagar smådjur";
            Forest.Add(a3);

            AnimalsinForest a4 = new AnimalsinForest();
            a4.Species = "Ekorren";
            a4.IsNocturnal = false;
            a4.Activity = "letar efter nötter tills den blir trötter";
            Forest.Add(a4);

                       

            while (true)
            {
                var activityText = "";

                Console.Clear();
                foreach (AnimalsinForest a in Forest)
                {
                    if (a.IsNocturnal == true && nightTime == true)
                    {

                        activityText = a.Activity;

                    }
                    else if (a.IsNocturnal == false && nightTime == false)
                    {

                        activityText = a.Activity;

                    }
                    else
                    {

                        activityText = "sover";

                    }

                    Console.WriteLine($"{a.Species} {activityText}.");                   

                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == 'd')
                {
                    nightTime = true;
                }
                if (key.KeyChar == 'n')
                {
                    nightTime = false;
                }

            }

            

        }
    }

    class AnimalsinForest
    {

        public string Species { get; set; }
        public bool IsNocturnal { get; set; }
        public string Activity { get; set; }

    }

}
