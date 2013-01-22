using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

/// <summary>
/// Summary description for Book
/// </summary>
[DataObject(true)]
public class Book
{
	public Book()
	{
	}

    public string ID { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Price { get; set; }
    public DateTime PublishDate { get; set; }
    public string Description { get; set; }

}