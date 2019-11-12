using System;
using System.Collections.Generic;

namespace MyBookshelf.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int? YearPublish { get; set; }
        public string BookGenre { get; set; }
        public DateTime? DateAdd { get; set; }
        public string UserName { get; set; }
        public bool? IsRead { get; set; }
    }
}