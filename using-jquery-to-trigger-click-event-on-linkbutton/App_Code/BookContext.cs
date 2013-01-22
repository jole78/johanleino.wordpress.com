using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.ComponentModel;

/// <summary>
/// Summary description for BookContext
/// </summary>
public class BookContext
{
	public BookContext()
	{
	}

    private List<Book > Books
    {
        get
        {
            List<Book> books = HttpContext.Current.Session["Books"] as List<Book>;

            //  load the books on first access
            if (books == null)
            {
                books = new List<Book>();
                //  load up the xml document
                XDocument xDoc = XDocument.Load(HttpContext.Current.Server.MapPath(@"App_Data\books.xml"));

                //  populate the books collection
                books =
                (
                    from b in xDoc.Descendants("book")

                    select new Book
                    {
                        ID = b.Attribute("id").Value,
                        Author = b.Element("author").Value,
                        Description = b.Element("description").Value,
                        Genre = b.Element("genre").Value,
                        Price = b.Element("price").Value,
                        PublishDate = Convert.ToDateTime(b.Element("publish_date").Value),
                        Title = b.Element("title").Value
                    }
                ).ToList();

                //  cache the list
                HttpContext.Current.Session["Books"] = books;
            }

            return books;
        }
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public IEnumerable<Book> FindAll()
    {
        return this.Books;
    }
}