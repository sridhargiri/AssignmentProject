using System;
using System.Collections.Generic;

namespace AssignmentDataLayer.Models;

public partial class Book
{
    /// <summary>
    /// The unique guid
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Name of book
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Name of the author
    /// </summary>
    public string AuthorName { get; set; }
}
