
namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }


        private List<Book> books;

        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
