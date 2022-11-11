using AssignmentDataLayer.Models;

namespace AssignmentRepository.Abstractions
{
    public interface IAssignmentBookRepository
    {
        /// <summary>
        /// get all books
        /// </summary>
        /// <returns></returns>
        List<Book> GetBooks();
        /// <summary>
        /// add book
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Guid AddBook(Book employee);
        /// <summary>
        /// get book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Book GetById(Guid id);
        /// <summary>
        /// delete a book
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);
        /// <summary>
        /// edit a book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        void Edit(Guid id, Book book);
    }
}