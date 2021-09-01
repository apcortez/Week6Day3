using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Day3.Core.Models;
using Week6Day3.EF.Repositories;

namespace Week6Day3.Client
{
    public class Menu
    {
        private static MainBL mainBL = new MainBL(new EFBookRepository());

        //Start -> menu .. premi 1... 

        //Altri metodi che contengono soltanto l'interfaccia con l'utente

     

        internal static void Start()
        {
            bool continuare = true;
            Console.WriteLine("################# BENVENUTO! ################");
            do
            {
                Console.WriteLine();
                Console.WriteLine("#############################################");
                Console.WriteLine("Selezionare un operazione da eseguire:");
                Console.WriteLine("1 - Visualizzare tutti i libri ");
                Console.WriteLine("2 - Aggiungere un libro");
                Console.WriteLine("3 - Eliminare un libro");
                Console.WriteLine("4 - Aggiornare quantità di un libro in magazzino");
                Console.WriteLine("0 - Per uscire");
                Console.WriteLine("#############################################");

                Console.WriteLine();
                Console.WriteLine("Quale operazione vuoi scegliere?");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        ShowBooks();
                        break;
                    case "2":
                        AddBook();
                        break;
                    case "3":
                        DeleteBook();
                        break;
                    case "4":
                        UpdateBookQuantity();
                        break;
                    case "0":
                        Console.WriteLine("Arrivederci. A presto!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }
        public static void ShowBooks()
        {
            var books = mainBL.FetchBooks();
            //Controllo che la lista non sia vuota
            //Stampo lista dei libri
            if (books != null)
            {
                foreach (var b in books)
                {
                    Console.WriteLine(b.Print());
                }
            }
            else throw new Exception("Libreria vuota.");
           
        }
        private static void UpdateBookQuantity()
        {
            List<Book> books = mainBL.FetchBooks();

            int i = 1;
            Console.WriteLine("Seleziona il libro da modificare: ");
            foreach (var book in books)
            {
                Console.WriteLine($"{i} - {book.Print()}");
                i++;
            }

            bool isInt;
            int bookScelto;
            do
            {
                Console.WriteLine("Quale libro vuoi modificare?");

                isInt = int.TryParse(Console.ReadLine(), out bookScelto);

            } while (!isInt || bookScelto <= 0 || bookScelto > books.Count);
            int quantita;
            quantita = InsertQuantity();
            Book newBook = books.ElementAt(bookScelto - 1);
            newBook.Quantity = quantita;
            mainBL.UpdateQuantity(newBook);
        }

      
        private static void DeleteBook()
        {
            List<Book> books = mainBL.FetchBooks();

            int i = 1;
            Console.WriteLine("Seleziona il libro da eliminare: ");
            foreach (var book in books)
            {
                Console.WriteLine($"{i} - {book.Print()}");
                i++;
            }

            bool isInt;
            int bookScelto;
            do
            {
                Console.WriteLine("Quale libro vuoi eliminare?");

                isInt = int.TryParse(Console.ReadLine(), out bookScelto);

            } while (!isInt || bookScelto <= 0 || bookScelto > books.Count);

            mainBL.DeleteBook(books.ElementAt(bookScelto - 1));

        }

        private static void AddBook()
        {
            Book book = new Book();
            book.Title = InsertTitle();
            book.Author = InsertAuthor();
            book.ISBN = InsertISBN();
            book.Quantity = InsertQuantity();
            mainBL.InsertBook(book);
        }

        private static string InsertISBN()
        {
            string isbn = String.Empty;
            do
            {
                Console.WriteLine("ISBN: ");
                isbn = Console.ReadLine();

            } while (String.IsNullOrEmpty(isbn));
            return isbn;
        }

        private static string InsertAuthor()
        {
            string author = String.Empty;
            do
            {
                Console.WriteLine("Autore: ");
                author = Console.ReadLine();

            } while (String.IsNullOrEmpty(author));
            return author;
        }

        private static string InsertTitle()
        {
            string title = String.Empty;
            do
            {
                Console.WriteLine("Titolo: ");
                title = Console.ReadLine();

            } while (String.IsNullOrEmpty(title));
            return title;
        }

        private static int InsertQuantity()
        {
            int quantity;
            bool isInt;
            do
            {
                Console.WriteLine("Quantita: ");

                isInt = int.TryParse(Console.ReadLine(), out quantity);

            } while (!isInt);
            return quantity;
        }

    }
}
