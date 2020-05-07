using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookManagement:UITooI
    {
        
        public void PrintBookList(List<BookInformation> bookList)
        {
            string divisionLine = new String('-', 50);
            //string blank = null;
            
            for(int order = 0;order < bookList.Count; order++)
            {
                Console.WriteLine(divisionLine);

                OneSpace((order+1).ToString(), 3);
                OneSpace(bookList[order].Name, 20);
                OneSpace(bookList[order].Author, 10);
                OneSpace(bookList[order].Publisher, 10);


                Console.Write(" " + bookList[order].Quantity + "개");
                Console.WriteLine();
            }

            Console.WriteLine(divisionLine);            
        }

        public BookInformation ModifyBookQuantity(BookInformation book)
        {
            return book;
        }

        public List<BookInformation> SerchByName(List<BookInformation> bookList)
        {
            List<BookInformation> SerchedBooks = new List<BookInformation>();

            return SerchedBooks;
        }

        public List<BookInformation> SerchByAuthor(List<BookInformation> bookList)
        {
            List<BookInformation> SerchedBooks = new List<BookInformation>();

            return SerchedBooks;
        }

        public List<BookInformation> SerchedByPublisher(List<BookInformation> bookList)
        {
            List<BookInformation> SerchedBooks = new List<BookInformation>();

            return SerchedBooks;
        }

        public List<BookInformation> DeleteBookData(List<BookInformation> bookList)
        {

            return bookList;
        }
    }
}
