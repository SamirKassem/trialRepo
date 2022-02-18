using System.Collections.Generic;
using System.Linq;
using trial.Data.Models;
using trial.Data.ViewModels;

namespace trial.Data.Services
{
    public class BooksService
    {
        private AppDbContext _db;
        public BooksService(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public void AddBook(BookVM book)
        {
            _db.Books.Add(new Book()
            {
                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                dateRead = book.isRead ? book.dateRead.Value : null,
                DateAdded = System.DateTime.Now,
                Rating = book.isRead ? book.Rating.Value : null, 
                Genre= book.Genre,
                coverUrl= book.coverUrl
            });
            _db.SaveChanges();
        }

        public List<Book> GetAllBooks() => _db.Books.ToList();

        public Book GetBookById(int Id)
        {
            return _db.Books.FirstOrDefault(b => b.Id == Id);
        }

        public Book UpdateBookById(int Id, BookVM bookVM)
        {
            Book book = _db.Books.FirstOrDefault(b => b.Id == Id);
            if(book != null)
            {
                book.Title = bookVM.Title;
                book.Description = bookVM.Description;
                book.isRead = bookVM.isRead;
                book.dateRead = bookVM.isRead ? bookVM.dateRead.Value : null;
                book.Rating = bookVM.isRead ? bookVM.Rating.Value : null;
                book.Genre = bookVM.Genre;
                book.coverUrl = bookVM.coverUrl;
            }
            _db.SaveChanges();
            return book;
        }

        public void DeleteBookById(int Id)
        {
            Book _book = _db.Books.FirstOrDefault(b => b.Id == Id);
            if(_book != null)
            {
                _db.Books.Remove(_book);
                _db.SaveChanges();
            }
        }
    }
}
