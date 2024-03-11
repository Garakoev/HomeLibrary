using Microsoft.VisualBasic;
using System.Data.SqlTypes;

namespace HomeLibrary.MVC.Models;

public class BooksList
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Author { get; set; }

    public string PublicationYear { get; set; }

    public string Edition { get; set; }

    public string TableOfContents { get; set; }
}