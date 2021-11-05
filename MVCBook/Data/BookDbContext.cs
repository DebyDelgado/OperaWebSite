using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCBook.Models;
using System.Data.Entity;

namespace MVCBook.Data
{
    public class BookDbContext:DbContext
    {
        public BookDbContext():base("KeyDB") { }
        public DbSet<Book> Books { get; set; }
    }
}