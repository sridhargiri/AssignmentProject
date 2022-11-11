using AssignmentDataLayer.Models;

namespace AssignmentService.Abstractions
{
    public interface IAssignmentBookService
    {
        /// <summary>
        /// get all books
        /// </summary>
        /// <returns></returns>
        List<Book> GetBooks();
        /// <summary>
        /// Adds a book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Guid AddBook(Book book);
        /// <summary>
        /// Get book by id
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
        /// edit a book record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        void Edit(Guid id, Book book);
    }
}