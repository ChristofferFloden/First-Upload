using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_1
{
    class Program
    {
        static void Main(string[] args)
        {

            TellStory();  // Anropar metoden Tellstory, som i sin tur
            
        }

        public static void TellStory() // I denna metod skapas en instans av ett Animal "a1" som sedan får olika  
        {                              // properties definierade. Sedan skrivs historien om animal a1 ut.   

            Animal a1 = new Animal();
            a1.AnimalType = "gris";
            a1.Name = "Oinky";
            a1.BirthYear = 2002;
            a1.Age = Animal.CalculateAge(a1.BirthYear);
            a1.NumberOfLimbs = 1;
            a1.LimbsLeft = Animal.CalculateLimbs(a1.NumberOfLimbs);
            a1.Speed = true;
            Console.WriteLine(Animal.BuildStory(a1));
            Console.ReadKey();

        }

                    
    }

    class Animal // Detta är klassen Animal där vi har en hel drös metoder som hjälper till att set:a och räkna
    {            //  ut ett visst Animals olika properties, vi har även en metod som skriver ihop historien.
        public string AnimalType { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int Age { get; set; }
        public int NumberOfLimbs { get; set; }
        public int LimbsLeft { get; set; }
        public bool Speed { get; set; }

        public static int CalculateAge(int YearOfBirth) // I denna metod räknas djurets ålder ut genom att jämföra dess födelseår med det nuvarande året
        {                                               // och berättar skillnaden, vilket ger "djurets ålder" +-1 beroende på när på året det föddes. 

            int realYear = DateTime.Now.Year;
            return realYear - YearOfBirth;

        }

        public static int CalculateLimbs(int LimbsBefore) // I denna metod räknar vi ut hur många ben djuret kommer ha kvar efter det fått 1 ben avbitet.
        {                                                 // Detta gör vi genom att ta antalet ben djuret hade från början och bara subtraherar 1 
                        
            return LimbsBefore - 1;

        }


        public static string BuildStory(Animal A) // I denna metod skapar vi en string som fylls med historien om djuret, vi använder olika properties för
        {                                         // djuret och berättar sedan historien lite olika beroende på hur många ben djuret har kvar i slutet. 

            string theStory = "Det var en gång en " + A.Age + " år gammal " + A.AnimalType + " som hette " + A.Name + ".\n";
            theStory += "En dag var " + A.Name + " ute på promenad I skogen, och mötte en stor varg.\n";
            theStory += "Vargen bet av ett ben. "; 
            if(A.Speed == true && A.LimbsLeft >= 2)
            {
                theStory += A.Name + " sprang snabbt hem på sina " + A.LimbsLeft + " ben.\n";
            }
            else if(A.Speed == false && A.LimbsLeft >= 2)
            {
                theStory += A.Name + " sprang långsamt hem på sina " + A.LimbsLeft + " ben.\n";
            }
            else if (A.Speed == true && A.LimbsLeft == 1)
            {
                theStory += A.Name + " hoppade snabbt hem på sitt " + A.LimbsLeft + " ben.\n";
            }
            else if (A.Speed == false && A.LimbsLeft == 1)
            {
                theStory += A.Name + " hoppade långsamt hem på sitt " + A.LimbsLeft + " ben.\n";
            }
            else if (A.LimbsLeft < 1)
            {
                theStory += A.Name + " hade inga ben kvar då han endast hade " + A.NumberOfLimbs + " ben från början.. så det blev mat till hela vargfamiljen!\n";
            }

            theStory += "\nSå var sagan slut!";


            return theStory;

        }

    }

}
