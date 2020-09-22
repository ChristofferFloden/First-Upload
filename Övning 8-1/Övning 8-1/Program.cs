using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_8_1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Book> library = new List<Book>();

            // Varje boks egenskaper ligger i följande ordning; Författare(string), Titel(string), Antal sidor(int).
            // Barnböcker har även följande egenskaper; Barn/Ungdom(string), Bildbok(bool).
            // Faktaböcker har även följande egenskaper; Svårighetsgrad(int), Ämne(string).
            // Underhållningsböcker har även följande egenskaper; Genre(string), Roman/Antologi(bool)

            library.Add(new ChildrensBook("Astrid lindgren", "Bröderna Lejonhjärta", 75, "Barnbok", false));
            library.Add(new ChildrensBook("Olle", "Apan och Grodan", 20, "Barnbok", true));
            library.Add(new FactBook("Åke Bloom", "Vilse i min egen trädgård", 50, 2, "Trädgårdsskötsel"));
            library.Add(new FactBook("Mikael Engström", "C# Grunderna", 300, 1, "Programmering"));
            library.Add(new EntertainmentBook("J.R.R. Tolkien", "Bilbo", 120, "Fantasy", true));
            library.Add(new EntertainmentBook("George R.R. Martin", "Storm of Swords", 420, "Fantasy", false));

            bool listFacts = false;
            bool listEntertainments = false;
            bool listChildrensbooks = false;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("-< Press to list the respective books >-");
                Console.Write("\n[E]ntertainmentbooks");
                if (listEntertainments == true)
                    Console.Write(" are shown\n");
                else
                    Console.Write(" are not shown\n");
                Console.Write("[C]hildrensbooks");
                if (listChildrensbooks == true)
                    Console.Write(" are shown\n");
                else
                    Console.Write(" are not shown\n");
                Console.Write("[F]actbooks");
                if (listFacts == true)
                    Console.Write(" are shown\n");
                else
                    Console.Write(" are not shown\n");

                Console.WriteLine("-----------------------------------\n");
                

                foreach (Book b in library)
                {
                    if (listChildrensbooks == true)
                    {

                        Console.WriteLine("Author: " + b.TheAuthor);
                        Console.WriteLine("Title: " + b.TheTitle);
                        Console.WriteLine("Number of pages: " + b.NumberOfPages);

                        if (b is ChildrensBook)
                        {
                            Console.WriteLine("Written for: " + ((ChildrensBook)b).ForChildOrYouth);
                            Console.WriteLine(((ChildrensBook)b).PictureBook ? "This is a picture-book" : "This is not a picture-book");
                        }

                        Console.WriteLine();
                    }
                
                
                    if (listFacts == true)
                    {

                        Console.WriteLine("Author: " + b.TheAuthor);
                        Console.WriteLine("Title: " + b.TheTitle);
                        Console.WriteLine("Number of pages: " + b.NumberOfPages);


                        if (b is FactBook)
                        {
                            Console.WriteLine("The book is about: " + ((FactBook)b).BookSubject);
                            Console.WriteLine("Difficulty level: " + ((FactBook)b).LevelOfDifficulty);
                        }

                        Console.WriteLine();

                    }
                

               
                    if (listEntertainments == true)
                    {

                        Console.WriteLine("Author: " + b.TheAuthor);
                        Console.WriteLine("Title: " + b.TheTitle);
                        Console.WriteLine("Number of pages: " + b.NumberOfPages);


                        if (b is EntertainmentBook)
                        {
                            Console.WriteLine("The book is in the genre: " + ((EntertainmentBook)b).BookType);
                            Console.WriteLine(((EntertainmentBook)b).NovelOrAnthology ? "This is a novel" : "This is an anthology");
                        }
                        Console.WriteLine();

                    }
                }



                ConsoleKeyInfo key = Console.ReadKey();

                if (key.KeyChar == 'f')
                {
                    if (listFacts == false)
                        listFacts = true;
                    else if (listFacts == true)
                        listFacts = false;                                        
                }

                if (key.KeyChar == 'e')
                {
                    if (listEntertainments == false)
                        listEntertainments = true;
                    else if (listEntertainments == true)
                        listEntertainments = false;
                }

                if (key.KeyChar == 'c')
                {
                    if (listChildrensbooks == false)
                        listChildrensbooks = true;
                    else if (listChildrensbooks == true)
                        listChildrensbooks = false;
                }


            }
        }
    }

    
    class Book
    {
        public string TheAuthor { get; set; }
        public string TheTitle { get; set; }
        public int NumberOfPages { get; set; }
    }

    class FactBook : Book
    {
        public int LevelOfDifficulty { get; set; }
        public string BookSubject { get; set; }

        public FactBook(string theauthor, string thetitle, int numberofpages, int levelofdifficulty, string booksubject)
        {
            TheAuthor = theauthor;
            TheTitle = thetitle;
            BookSubject = booksubject;
            NumberOfPages = numberofpages;
            LevelOfDifficulty = levelofdifficulty;
        }

    }

    class ChildrensBook : Book
    {
        public string ForChildOrYouth { get; set; }
        public bool PictureBook { get; set; }

        public ChildrensBook(string theauthor, string thetitle, int numberofpages, string forchildoryouth,  bool picturebook)
        {
            TheAuthor = theauthor;
            TheTitle = thetitle;
            NumberOfPages = numberofpages;
            ForChildOrYouth = forchildoryouth;
            PictureBook = picturebook;
        }

    }

    class EntertainmentBook : Book
    {
        public string BookType { get; set; }
        public bool NovelOrAnthology { get; set; }

        public EntertainmentBook(string theauthor, string thetitle, int numberofpages, string booktype, bool noveloranthology)
        {
            TheAuthor = theauthor;
            TheTitle = thetitle;
            NumberOfPages = numberofpages;
            BookType = booktype;
            NovelOrAnthology = noveloranthology;
        }

    }
}
