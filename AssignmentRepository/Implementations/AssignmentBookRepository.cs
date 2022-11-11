using AssignmentDataLayer.DataContext;
using AssignmentDataLayer.Models;
using AssignmentRepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace AssignmentRepository.Implementations
{
    public class AssignmentBookRepository : IAssignmentBookRepository
    {
        private readonly AssignmentDbContext _dbContext;
        public AssignmentBookRepository(AssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return book.Id;
        }

        public List<Book> GetBooks()
        {
            var set = _dbContext.Books.ToList();
            return set;
        }

        public Book GetById(Guid id)
        {
            var book = _dbContext.Books.Where(t => t.Id == id).FirstOrDefault();
            if (book != null)
            {
                return book;
            }
            return null;
        }
        public void Delete(Guid id)
        {
            var book = _dbContext.Books.Where(t => t.Id == id).FirstOrDefault();
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }
        public void Edit(Guid id, Book book)
        {
            var bookRecord = _dbContext.Books.Where(t => t.Id == id).FirstOrDefault();
            if (bookRecord != null)
            {
                bookRecord.Name = book.Name;
                bookRecord.AuthorName = book.AuthorName;
                _dbContext.SaveChanges();
            }
        }
    }
}
