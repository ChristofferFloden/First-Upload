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
            // Underhållningsböcker har även följande egenskaper; Genre(string), Roman/Antologi(string)

            library.Add(new ChildrensBook("Astrid lindgren", "Bröderna Lejonhjärta", 75, "Barnbok", false));
            library.Add(new ChildrensBook("Olle", "Apan och Grodan", 20, "Barnbok", true));
            library.Add(new FactBook("Åke Bloom", "Vilse i min egen trädgård", 50, 2, "Trädgårdsskötsel"));
            library.Add(new FactBook("Mikael Engström", "C# Grunderna", 300, 1, "Programmering"));
            library.Add(new EntertainmentBook("J.R.R. Tolkien", "Bilbo", 120, "Fantasy", "Roman"));
            library.Add(new EntertainmentBook("George R.R. Martin", "Storm of Swords", 420, "Fantasy", "Anthology"));



            foreach (Book b in library)
            {
                Console.WriteLine("Author: " + b.TheAuthor);
                Console.WriteLine("Title: " + b.TheTitle);
                Console.WriteLine("Number of pages: " + b.NumberOfPages);

                if (b is ChildrensBook)
                {
                    Console.WriteLine("Written for: " + ((ChildrensBook)b).ForChildOrYouth);

                    if (((ChildrensBook)b).Picturebook == true)
                    {

                                    
                            
                    }

                    Console.WriteLine(((ChildrensBook)b).PictureBook ? "This is a picture-book" : "This is not a picture-book");
                }
                if (b is FactBook)
                {
                    Console.WriteLine("The book is about: " + ((FactBook)b).BookSubject); 
                }
                if (b is EntertainmentBook)
                {
                    Console.WriteLine("The book is in the genre: " + ((EntertainmentBook)b).BookType); 
                }
                Console.WriteLine();               

            }

            Console.ReadKey();
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
        public string NovelOrAnthology { get; set; }

        public EntertainmentBook(string theauthor, string thetitle, int numberofpages, string booktype, string noveloranthology)
        {
            TheAuthor = theauthor;
            TheTitle = thetitle;
            NumberOfPages = numberofpages;
            BookType = booktype;
            NovelOrAnthology = noveloranthology;

        }

    }
}
