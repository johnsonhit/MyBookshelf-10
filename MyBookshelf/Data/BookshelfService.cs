using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookshelf.Data;

namespace MyBookshelf.Data
{
    public class BookshelfService
    {
        private readonly ApplicationDbContext _context;

        public BookshelfService(ApplicationDbContext context)

        {
            _context = context;
        }


        //// count books
        //public Task<int> GetNumberReadBooksAsync(bool onlyRead)
        //{
        //    if (onlyRead == true)
        //    {
        //        _context.Books.Where(c => c.IsRead == true).Load();
        //    }
        //    else if (onlyRead == false)
        //    {
        //        _context.Books.Where(c => c.IsRead == false).Load();
        //    }

        //    return Task.FromResult(_context.Books.Local.Count);
        //}

        public Task<int> GetCountBooksAsync(bool isRead)
        {
            if (isRead == true)
            {
                _context.Books.Where(c => c.IsRead == true).Load();
            }
            else if (isRead == false)
            {
                _context.Books.Where(c => c.IsRead == false).Load();
            }

            return Task.FromResult(_context.Books.Local.Count);
        }

        // get book (read or desired)
        public Task<List<Book>> GetBookAsync(string strCurrentUser, bool isRead)
        {
            List<Book> colBooks = new List<Book>();
            if (isRead == true)
            {
                colBooks =
                (from book in _context.Books
                 where (book.UserName == strCurrentUser && book.IsRead == true)
                 select book).ToList();
            }

            else if (isRead == false)
            {
                colBooks =
                (from book in _context.Books
                 where (book.UserName == strCurrentUser && book.IsRead == false)
                 select book).ToList();
            }

            return Task.FromResult(colBooks);
        }

        // Get genres
        public Task<List<Genre>> GetGenresAsync()
        {
            List<Genre> colGenres = new List<Genre>();
            colGenres = _context.Genres.ToList();
            return Task.FromResult(colGenres);
        }

        // create book
        public Task<Book> CreateBookAsync(Book objBook)
        {
            _context.Books.Add(objBook);
            _context.SaveChanges();
            return Task.FromResult(objBook);
        }

        // Create genre
        public Task<Genre> CreateGenreAsync(Genre objGenre)
        {
            _context.Genres.Add(objGenre);
            _context.SaveChanges();
            return Task.FromResult(objGenre);
        }

        // update book(s)
        public Task<bool> UpdateBookAsync(Book objBook)
        {
            var ExistingBook = _context.Books
                                .Where(x => x.Id == objBook.Id)
                                .FirstOrDefault();

            if (ExistingBook != null)
            {
                ExistingBook.DateAdd = objBook.DateAdd;
                ExistingBook.BookName = objBook.BookName;
                ExistingBook.AuthorName = objBook.AuthorName;
                ExistingBook.BookGenre = objBook.BookGenre;
                ExistingBook.YearPublish = objBook.YearPublish;

                _context.SaveChanges();
            }

            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        // Update genre(s)
        public Task<bool> UpdateGenreAsync(Genre objGenre)
        {
            var ExistingGenre = _context.Genres
                                .Where(x => x.Id == objGenre.Id)
                                .FirstOrDefault();

            if (ExistingGenre != null)
            {
                ExistingGenre.Name = objGenre.Name;

                _context.SaveChanges();
            }

            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        // Delete book
        public Task<bool> DeleteBookAsync(Book objBook)
        {
            var ExistingBook = _context.Books
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

        // Delete genre
        public Task<bool> DeleteGenreAsync(Genre objGenre)
        {
            var ExistingGenre = _context.Genres
                               .Where(x => x.Id == objGenre.Id)
                               .FirstOrDefault();

            if (ExistingGenre != null)
            {
                _context.Genres.Remove(ExistingGenre);
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