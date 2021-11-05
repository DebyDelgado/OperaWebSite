using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCBook.Models;

namespace MVCBook.Data
{
    public class BookInitializer : DropCreateDatabaseAlways<BookDbContext>
    {
        protected override void Seed(BookDbContext context)
        {
            var books = new List<Book>
            {
                new Book
            {   Name = "El libro de los 5 anillos",
            Author = "Miyamoto Musashi",
            PagesNumber = 900,
            Publisher= "Musashi",
            PublicationDate = "2016-08-04",
            Content =".....",
            Price =1112,
            PriceConfirm=1112

            }

            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }   

    }
}