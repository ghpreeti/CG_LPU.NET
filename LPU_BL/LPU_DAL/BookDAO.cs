using System;
using System.Collections.Generic;
using LPU_Common;
using LPU_Entity;
using LPU_Exceptions;

namespace LPU_DAL
{
    public class BookDAO : IRepo<Book>
    {
        static List<Book> bookList = null;

        public BookDAO()
        {
            if (bookList == null)
            {
                bookList = new List<Book>()
                {
                    new Book { ISBNNo = 1, Title = "C# Basics", Author = "MS", Price = 450 },
                    new Book { ISBNNo = 2, Title = "ASP.NET", Author = "Scott", Price = 550 },
                    new Book { ISBNNo = 3, Title = "Data Structures", Author = "Mark", Price = 600 },
                    new Book { ISBNNo = 4, Title = "Java Programming", Author = "Herbert", Price = 500 },
                    new Book { ISBNNo = 5, Title = "Python Essentials", Author = "Guido", Price = 480 },
                    new Book { ISBNNo = 6, Title = "Operating Systems", Author = "Silberschatz", Price = 650 },
                    new Book { ISBNNo = 7, Title = "Database Systems", Author = "Elmasri", Price = 700 },
                    new Book { ISBNNo = 8, Title = "Computer Networks", Author = "Tanenbaum", Price = 620 },
                    new Book { ISBNNo = 9, Title = "Software Engineering", Author = "Pressman", Price = 580 }

                };
            }
        }

        public bool AddDetails(Book obj)
        {
            if (obj != null)
            {
                bookList.Add(obj);
                return true;
            }
            throw new BookException("Invalid book data");
        }

        public bool DeleteDetails(int id)
        {
            Book b = bookList.Find(x => x.ISBNNo == id);
            if (b != null)
            {
                bookList.Remove(b);
                return true;
            }
            throw new BookException("Book not found");
        }

        public List<Book> ShowAll()
        {
            return bookList;
        }

        public Book ShowDetailsByID(int id)
        {
            Book b = bookList.Find(x => x.ISBNNo == id);
            if (b != null)
            {
                return b;
            }
            throw new BookException("Book not found");
        }

        public bool UpdateDetails(int id, Book obj)
        {
            Book b = bookList.Find(x => x.ISBNNo == id);
            if (b != null && obj != null)
            {
                b.Title = obj.Title;
                b.Author = obj.Author;
                b.Price = obj.Price;
                return true;
            }
            throw new BookException("Unable to update book");
        }
    }
}
