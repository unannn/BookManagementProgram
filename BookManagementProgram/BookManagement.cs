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
            string divisionLine = new String('-', 76);
            //string blank = null;
            
            for(int order = 0;order < bookList.Count; order++)
            {
                Console.WriteLine(divisionLine);

                OneSpace((order+1).ToString(), 3);
                OneSpace(bookList[order].Name, 30);  
                OneSpace(bookList[order].Author, 20);
                OneSpace(bookList[order].Publisher, 10);


                Console.Write(" " + bookList[order].Quantity + "권");
                Console.WriteLine();
            }

            Console.WriteLine(divisionLine);            
        }

        public void PrintBookListForReturn(List<BookInformation> bookList)
        {
            string divisionLine = new String('-', 72);
            //string blank = null;

            for (int order = 0; order < bookList.Count; order++)
            {
                Console.WriteLine(divisionLine);

                OneSpace((order + 1).ToString(), 3);
                OneSpace(bookList[order].Name, 30);
                OneSpace(bookList[order].Author, 20);
                OneSpace(bookList[order].Publisher, 10);
                                
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
            List<BookInformation> serchedBooks = new List<BookInformation>();
            string inputString = null;

            Console.Write("도서 이름 입력 : ");
            Console.Write("                  ");
            Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);

            inputString = ExceptionHandling.InputString(1, 20);
            
            
            for (int book = 0; book < bookList.Count; book++)
            {
                if (bookList[book].Name.Contains(inputString))   //검색된 문자열이 책이름에 포함되는 책리스트의 책이 있으면
                {
                    serchedBooks.Add((BookInformation)bookList[book]);   //복사해서 serchedBooks 리스트에 추가
                }
            }

            return serchedBooks;
        }

        public List<BookInformation> SerchByAuthor(List<BookInformation> bookList)
        {
            List<BookInformation> serchedBooks = new List<BookInformation>();
            string inputString = null;

            Console.Write("도서 저자 입력 : ");
            Console.Write("                  ");
            Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);

            inputString = ExceptionHandling.InputString(1, 20);


            for (int book = 0; book < bookList.Count; book++)
            {
                if (bookList[book].Author.Contains(inputString))   //검색된 문자열이 책이름에 포함되는 책리스트의 책이 있으면
                {
                    serchedBooks.Add((BookInformation)bookList[book]);   //복사해서 serchedBooks 리스트에 추가
                }
            }

            return serchedBooks;
        }

        public List<BookInformation> SerchedByPublisher(List<BookInformation> bookList)
        {
            List<BookInformation> serchedBooks = new List<BookInformation>();
            string inputString = null;

            Console.Write("도서 출판사 입력 : ");
            Console.Write("                  ");
            Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);

            inputString = ExceptionHandling.InputString(1, 20);


            for (int book = 0; book < bookList.Count; book++)
            {
                if (bookList[book].Publisher.Contains(inputString))   //검색된 문자열이 책이름에 포함되는 책리스트의 책이 있으면
                {
                    serchedBooks.Add((BookInformation)bookList[book]);   //복사해서 serchedBooks 리스트에 추가
                }
            }

            return serchedBooks;
        }

        public List<BookInformation> DeleteBookData(List<BookInformation> bookList)
        {

            return bookList;
        }
    }
}
