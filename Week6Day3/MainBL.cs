using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Day3.Core.Interfaces;
using Week6Day3.Core.Models;

namespace Week6Day3
{
    public class MainBL
    {
        private IBookRepository _bookRepo;
        public MainBL(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }
        public List<Book> FetchBooks()
        {
            return _bookRepo.Fetch();
        }

        public void DeleteBook(Book book)
        {
            _bookRepo.Delete(book);
        }

        public void InsertBook(Book book)
        {
            _bookRepo.Insert(book);
        }

        public void UpdateQuantity(Book book)
        {
            _bookRepo.Update(book);
        }
    }
}
