using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class books
    {
        public string Bookname { get; set; }
        public string Authorname { get; set; }

        public books(string bookname, string authorname)
        {
            Bookname = bookname;
            Authorname = authorname;
        }

        public void Display()
        {
            Console.WriteLine("Bookname: " + Bookname);
            Console.WriteLine("Author Name: " + Authorname);
        }

        class BookShelf
        {
            books[] b = new books[5];
            public books this[int index]
            {
                get
                {
                    if (index < 0 || index >= b.Length)
                    {
                        Console.WriteLine("Invalid index");
                        return null;
                    }
                    return b[index];
                }
                set
                {
                    if (index < 0 || index >= b.Length)
                    {
                        Console.WriteLine("Invalid index; book could not be added");
                    }
                    else
                    {
                        b[index] = value;
                    }
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                BookShelf bs = new BookShelf();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Enter the details for book" + " " + (i + 1));
                    Console.Write("Book Name: ");
                    string bookName = Console.ReadLine();
                    Console.Write("Author Name: ");
                    string authorName = Console.ReadLine();
                    bs[i] = new books(bookName, authorName);
                }

                Console.WriteLine();
                Console.WriteLine("Books on the bookshelf:");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Book" + " " + (i + 1));
                    books book = bs[i];
                    if (book != null)
                        book.Display();
                }
                Console.ReadKey();
            }
        }
    }
}
