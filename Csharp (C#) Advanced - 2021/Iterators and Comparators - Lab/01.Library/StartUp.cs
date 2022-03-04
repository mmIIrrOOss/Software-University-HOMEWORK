
namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            Book bookOne = new Book("Animal Farm", 2003,"George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002,"Dorothy Sayers","Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);
            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo);
            Library libraryThree = new Library(bookOne, bookTwo, bookThree);
            Console.WriteLine("First library");
            foreach (var book in libraryOne)
            {
                Console.WriteLine($"{book.Title} - {book.Year} - {book.Authors}");
            }
            Console.WriteLine("Second library");
            foreach (var book in libraryTwo)
            {
                Console.WriteLine($"{book.Title} - {book.Year} - {book.Authors}");
            }
            Console.WriteLine("Third library");
            foreach (var book in libraryThree)
            {
                Console.WriteLine($"{book.Title} - {book.Year} - {book.Authors}");

            }
        }
    }
}
