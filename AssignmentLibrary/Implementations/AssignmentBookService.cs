using AssignmentDataLayer.Models;
using AssignmentRepository.Abstractions;
using AssignmentService.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentService.Implementations
{
    public class AssignmentBookService : IAssignmentBookService
    {
        private IAssignmentBookRepository _repository;
        public AssignmentBookService(IAssignmentBookRepository repository)
        {
            _repository = repository;
        }

        public Guid AddBook(Book book)
        {
            var id = _repository.AddBook(book);
            return id;
        }

        public List<Book> GetBooks()
        {
            return _repository.GetBooks();
        }
        public Book GetById(Guid id)
        {
            return _repository.GetById(id);
        }
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
        public void Edit(Guid id, Book book)
        {
            _repository.Edit(id, book);
        }
    }
}
