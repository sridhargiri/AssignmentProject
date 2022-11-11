using AssignmentProject.Model;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AssignmentDataLayer.Models;
using System.Net;
using AssignmentService.Abstractions;

namespace AssignmentProject.Controllers
{
    [ApiController()]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        public readonly IMapper _mapper;
        private readonly IAssignmentBookService _assignmentBookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IMapper mapper, ILogger<BooksController> logger, IAssignmentBookService assignmentBookService)
        {
            _mapper = mapper;
            _logger = logger;
            _assignmentBookService = assignmentBookService;
        }

        [HttpGet("GetAllBooks")]
        [Produces("application/json")]
        public IActionResult GetAll()
        {
            var set1 = _assignmentBookService.GetBooks();
            var _mappedUser = _mapper.Map<List<BookModel>>(set1);
            return Ok(_mappedUser);
        }
        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("AddBook")]
        [Consumes("application/json")]
        public IActionResult Post(BookModel book)
        {
            if (ModelState.IsValid)
            {
                var _book = _mapper.Map<Book>(book);
                var id = _assignmentBookService.AddBook(_book);
                return CreatedAtRoute("BookAdded", new { id = id }, new { id = id });
            }
            else
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// This is the created at route endpoint (not for the customer)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BookAdded/{id}", Name = "BookAdded")]
        public IActionResult BookAdded(Guid id)
        {
            return Ok(id);
        }
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id:Guid}")]
        [Produces("application/json")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var book = _assignmentBookService.GetById(id);
                var _book = _mapper.Map<BookModel>(book);
                if (_book != null)
                {
                    return Ok(_book);
                }
                else
                {

                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                return Problem(e.Message);
            }
        }
        /// <summary>
        /// Delete row
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _assignmentBookService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// edit record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [HttpPut("Edit/{id:Guid}")]
        public IActionResult Edit(Guid id, BookModel bookModel)
        {
            try
            {
                var _book = _mapper.Map<Book>(bookModel);
                _assignmentBookService.Edit(id, _book);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}