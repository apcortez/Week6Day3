using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Day3.Core.Interfaces;
using Week6Day3.Core.Models;

namespace Week6Day3.EF.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        private readonly BookContext bookCtx;

        public EFBookRepository()
        {
            bookCtx = new BookContext();
        }

        public void Delete(Book book)
        {
            bookCtx.Books.Remove(book);
            bookCtx.SaveChanges();
        }

        public List<Book> Fetch()
        {
            var books = bookCtx.Books.ToList();
            return books;
        }

        public Book GetById(int? id)
        {
            return bookCtx.Books.FirstOrDefault(b => b.Id == id);
        }

        public void Insert(Book book)
        {   
            bookCtx.Books.Add(book);
            bookCtx.SaveChanges();
        }

        public void Update(Book book)
        {
            var bookToUpdate = GetById(book.Id);
            bookToUpdate.Quantity = book.Quantity;
            bookCtx.SaveChanges();
            
        }
    }
}
