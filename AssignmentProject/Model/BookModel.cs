using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AssignmentProject.Model
{
    public class BookModel
    {
        /// <summary>
        /// The unique guid
        /// </summary>
        [JsonIgnore]
        public Guid Id { get; set; }
        /// <summary>
        /// Name of book
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        /// <summary>
        /// Name of the author
        /// </summary>
        [Required(ErrorMessage = "Author Name is required")]
        [Display(Name = "Author Name")]
        public string? AuthorName { get; set; }
    }
}