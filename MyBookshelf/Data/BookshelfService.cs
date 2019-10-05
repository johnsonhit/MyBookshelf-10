using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookshelf.Data;

namespace MyBookshelf.Data
{
    public class BookshelfService
    {
        private readonly MyBookshelfContext _context;

        public BookshelfService(MyBookshelfContext context)

        {
            _context = context;
        }

        //get book (read or desired)
        public Task<List<Book>>
            GetBookAsync(string strCurrentUser, bool isRead)

        {
            List<Book> colBooks =
                new List<Book>();
            if (isRead == true)
            {
                colBooks =
                (from book in _context.Books
                 // only get entries for the current logged in user
                 where (book.UserName == strCurrentUser && book.IsRead == true)
                 select book).ToList();
            }
            else if (isRead == false)
            {
                colBooks =
                (from book in _context.Books
                 // only get entries for the current logged in user
                 where (book.UserName == strCurrentUser && book.IsRead == false)
                 select book).ToList();
            }
            

            return Task.FromResult(colBooks);
        }


        //create book
        public Task<Book>
            CreateBookAsync(Book objBook)

        {
            _context.Books.Add(objBook);

            _context.SaveChanges();

            return Task.FromResult(objBook);
        }

        //update book(s)
        public Task<bool>
            UpdateBookAsync(Book objBook)

        {
            var ExistingBook =
                _context.Books
                    .Where(x => x.Id == objBook.Id)
                    .FirstOrDefault();

            if (ExistingBook != null)

            {
                ExistingBook.DateAdd =
                    objBook.DateAdd;

                ExistingBook.BookName =
                    objBook.BookName;

                ExistingBook.AuthorName =
                    objBook.AuthorName;

                ExistingBook.BookGenre =
                    objBook.BookGenre;

                ExistingBook.YearPublish =
                    objBook.YearPublish;

                _context.SaveChanges();
            }
            else

            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool>
            DeleteBookAsync(Book objBook)

        {
            var ExistingBook =
                _context.Books
                    .Where(x => x.Id == objBook.Id)
                    .FirstOrDefault();

            if (ExistingBook != null)

            {
                _context.Books.Remove(ExistingBook);

                _context.SaveChanges();
            }
            else

            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
