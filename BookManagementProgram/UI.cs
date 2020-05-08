using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class InputNumberRange
    {
        public const int startNumber = 1;
        public const int inputLocationX = 34;
        public const int inputLocationY = 5;
    }
    class User
    {
        public const int logIn = 1;
        public const int createAccount = 2;
        public const int endProgram = 3;
    }

    class UI : CustomerManagement
    {

        public int LogInOrCreateAccount()
        {
            string inputNumberInString = null;
            int inputNumber = -2;
            List<string> initialMenu = new List<string>()
            {
                "로그인 1",
                "회원가입 2",
                "종료 3"
            };

            while(inputNumber < 0)
            {
                PrintTitle();


                Console.Write($"{initialMenu[0]} {initialMenu[1]} {initialMenu[2]} 입력 : ");
                if(inputNumber == ExceptionHandling.wrongInput)Console.Write("\n다시 입력해 주세요.");

                Console.SetCursorPosition(InputNumberRange.inputLocationX, InputNumberRange.inputLocationY);
                inputNumberInString = Console.ReadLine();

                inputNumber = ExceptionHandling.InputNumber(InputNumberRange.startNumber, initialMenu.Count, inputNumberInString);

                Console.Clear();
            }

            return inputNumber;
        }
        
        public CustomerInformation LoginCustomer(List<CustomerInformation> customerList)
        {
            string id = null;
            string password = null;
            CustomerInformation loginCustomer = null;
            int inputInspection = 0;

            while (loginCustomer == null)
            {
                PrintTitle();


                InputIdAndPassword(ref id, ref password, inputInspection);

                if (id == null && password == null) return null;

                foreach(CustomerInformation customer in customerList)
                {
                    if(customer.Id == id && customer.Password == password)
                    {
                        loginCustomer = (CustomerInformation)customer.Clone();  //깊은복사
                    }
                }

                inputInspection = -1;
                Console.Clear();
            }
            
            return loginCustomer;
        }

        public CustomerInformation CreateCustomerAccount(List<CustomerInformation> customerList)
        {
            CustomerInformation customerToBeAdded = new CustomerInformation();
            NewAccountException newAccountException = new NewAccountException();

            bool loginSucessful = false;
            bool sameIdContinue = false;

            while (!loginSucessful)
            {
                Console.Clear();

                PrintTitle();
                
                customerToBeAdded = InputCustomerAccountInformation(newAccountException);

                if (newAccountException.previousOrStay == "stay")
                {
                    newAccountException.previousOrStay = " ";

                    continue;
                }
                else if (newAccountException.previousOrStay == "previous")
                {
                    newAccountException.previousOrStay = " ";
                    Console.Clear();
                    return null;
                }
                
                foreach(CustomerInformation customer in customerList)
                {
                    if (string.Compare(customerToBeAdded.Id, customer.Id) == 0)  //같은 아이디 존재
                    {
                        newAccountException.sameId = true;
                        sameIdContinue = true;
                    }
                }

                if (sameIdContinue)
                {
                    sameIdContinue = false;
                    continue;
                }

                if (customerToBeAdded.Id == null)
                {
                    newAccountException.wrongId = true;
                    continue;
                }

                if (customerToBeAdded.Password == null)
                {
                    newAccountException.wrongPassword = true;
                    continue;
                }

                if (customerToBeAdded.Name == null)
                {
                    newAccountException.wrongName = true;
                    continue;
                }

                if(customerToBeAdded.PhoneNumber == null)
                {
                    newAccountException.wrongPhoneNumber = true;
                    continue;
                }

                if (customerToBeAdded.Adress == null)
                {
                    newAccountException.wrongAdress = true;
                    continue;
                }

                loginSucessful = true;

                Console.Clear();
            }

            return customerToBeAdded;
        }
              
        public int PrintAdministratorUserMenu()
        {           
            List<string> Menu = new List<string>(){
               "1. 도서 리스트 보기/검색/대여",
               "2. 도서 반납",
               "3. 도서 등록",
               "4. 도서 삭제",
               "5. 회원 리스트 보기",
               "6. 회원 삭제",
               "7. 내 정보 수정",                             
               "8. 로그아웃",
               "9. 프로그램 종료"
            };
            int inputNumber = ExceptionHandling.wrongInput;  //inputNumber 초기화
            string inputNumberInString = null;

            while (inputNumber == ExceptionHandling.wrongInput)
            {
                PrintTitle();

                PrintMenuList(Menu);

                Console.Write("1 ~ 9입력 : ");

                inputNumberInString = Console.ReadLine();
                inputNumber = ExceptionHandling.InputNumber(1, Menu.Count, inputNumberInString);

                Console.Clear();
            }

           

            return inputNumber;
        }

        public int PrintUserMenu()
        {
            List<string> menu = new List<string>(){
               "1. 도서 리스트 보기/검색/대여",
               "2. 도서 반납",
               "3. 내 정보 수정",                           
               "4. 로그아웃",
               "5. 프로그램 종료"
            };
            int inputNumber = ExceptionHandling.wrongInput;  //inputNumber 초기화
            string inputNumberInString = null;

            while (inputNumber == ExceptionHandling.wrongInput)
            {
                PrintTitle();

                PrintMenuList(menu);

                Console.Write("1 ~ 5입력 : ");

                inputNumberInString = Console.ReadLine();
                inputNumber = ExceptionHandling.InputNumber(1, menu.Count, inputNumberInString);

                Console.Clear();
            }
                        
            return inputNumber;
        }
        //public void RentBook(CustomerInformation loginCustomer,List<BookInformation> bookList)
        //{
        //    PrintTitle();


        //}
        public void PrintAndSerchAndRentBook(List<BookInformation> bookList,CustomerInformation logInCustomer)
        {
            BookManagement bookManageMent = new BookManagement();
            List<BookInformation> serchingBookList = new List<BookInformation>();
            List<string> controlMenu = new List<string>(){
               "1. 도서 이름 검색",
               "2. 도서 저자 검색",
               "3. 도서 출판사 검색",
               "4. 도서 대여",
               "5. 나가기"
            };
            int inputNumber = 0;  //inputNumber 초기화
            string inputNumberInString = null;
            bool isEnd = false;

            while (!isEnd)
            {
                PrintTitle();

                bookManageMent.PrintBookList(bookList);

                PrintMenuList(controlMenu);

                Console.Write("1~5 정수 입력 : ");

                if (inputNumber == ExceptionHandling.wrongInput)
                {
                    Console.Write("\n다시 입력해 주세요");
                    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop - 1);
                }

                inputNumberInString = Console.ReadLine();
                inputNumber = ExceptionHandling.InputNumber(1, controlMenu.Count, inputNumberInString);

                if(inputNumber == ExceptionHandling.wrongInput)
                {
                    Console.Clear();
                    continue;
                }
                

                switch (inputNumber)
                {
                    case 1:       //이름으로 검색
                        serchingBookList = bookManageMent.SerchByName(bookList);
                        Console.Clear();
                        PrintTitle();
                        if (serchingBookList.Count > 0)
                        {
                            bookManageMent.PrintBookList(serchingBookList);
                            RentBook(logInCustomer, serchingBookList);
                        }
                        else
                        {
                            Console.WriteLine("해당 도서가 존재하지 않습니다");
                            Console.WriteLine("Press Any Key...");
                            
                            Console.ReadKey();
                        }
                        break;
                    case 2:        //저자로 검색
                        serchingBookList = bookManageMent.SerchByAuthor(bookList);
                        Console.Clear();
                        PrintTitle();
                        if (serchingBookList.Count > 0)
                        {
                            bookManageMent.PrintBookList(serchingBookList);
                            RentBook(logInCustomer, serchingBookList);
                        }
                        else
                        {
                            Console.WriteLine("해당 도서가 존재하지 않습니다");
                            Console.WriteLine("Press Any Key...");

                            Console.ReadKey();
                        }
                        break;
                    case 3:  //출판사로 검색
                        serchingBookList = bookManageMent.SerchedByPublisher(bookList);
                        Console.Clear();
                        PrintTitle();
                        if (serchingBookList.Count > 0)
                        {
                            bookManageMent.PrintBookList(serchingBookList);
                            RentBook(logInCustomer, serchingBookList);
                        }
                        else
                        {
                            Console.WriteLine("해당 도서가 존재하지 않습니다");
                            Console.WriteLine("Press Any Key...");

                            Console.ReadKey();
                        }
                        break;
                    case 4:    //도서대여
                        RentBook(logInCustomer, bookList);
                        break;
                    case 5:
                        isEnd = true;
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
        }

        private void RentBook(CustomerInformation logInCustomer,List<BookInformation> bookList)
        {
            int inputNumber = 0;
            string inputNumberInString = null;

            Console.Write("대여할 책 번호 입력 : ");
            inputNumberInString = Console.ReadLine();
            inputNumber = ExceptionHandling.InputNumber(1, bookList.Count, inputNumberInString);

            if(inputNumber != ExceptionHandling.wrongInput && bookList[inputNumber - 1].Quantity > 0) //올바른 번호가 입력되고 남은 수량이 있으면
            {
                foreach(BookInformation rentedBook in logInCustomer.RentedBook)
                {
                    if(rentedBook == bookList[inputNumber - 1]) //이미 대여중인 책이면
                    {
                        Console.WriteLine("이미 대여한 도서입니다.");
                        Console.WriteLine("Press Any Key...");
                        Console.ReadKey();
                        return;
                    }
                }

                bookList[inputNumber - 1].Quantity -= 1;
                logInCustomer.RentedBook.Add(bookList[inputNumber - 1]);
                Console.WriteLine("대여가 완료되었습니다.");
                Console.WriteLine("Press Any Key...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("해당 도서가 존재하지 않습니다.");
                Console.WriteLine("Press Any Key...");
                Console.ReadKey();
            }

        }

        public void PrintBookReturn( CustomerInformation logInCustomer, List<BookInformation> bookList)
        {
            BookManagement bookMangement = new BookManagement();
            string inputNumberInString;
            int inputNumber;
            bool isEnd = false;


            while (!isEnd)
            {
                Console.Clear();

                PrintTitle();

                Console.WriteLine("대여중인 도서 목록\n");
                bookMangement.PrintBookListForReturn(logInCustomer.RentedBook);

                Console.Write("반납 할 책 번호 입력 : ");
                inputNumberInString = Console.ReadLine();
                inputNumber = ExceptionHandling.InputNumber(1,logInCustomer.RentedBook.Count,inputNumberInString);
                
               if(inputNumber != ExceptionHandling.wrongInput)
                {
                    foreach(BookInformation book in bookList)
                    {
                        if (book.Name == logInCustomer.RentedBook[inputNumber - 1].Name) book.Quantity += 1;    //같은 제목의 책을 리스트에찾아 반납
                    }

                    logInCustomer.RentedBook.RemoveAt(inputNumber - 1);       //대여한 도서 목록에서 삭제

                    Console.WriteLine("반납이 완료 됐습니다.");
                    Console.WriteLine("Press Any Key...");
                    Console.ReadKey();
                    Console.Clear();
                    isEnd = true;
                }               
            }

        }
        public void ModifyMyData(CustomerInformation logInCustomer)
        {
            bool isEnd = false;
            int inputNumber = 0;
            string inputNumberInString = null;

            while (!isEnd)
            {
                Console.Clear();

                PrintTitle();
                
                Console.WriteLine("          내 정보\n");
                Console.Write("\n      이름 : " + logInCustomer.Name);
                Console.WriteLine("  휴대폰번호 : " + logInCustomer.PhoneNumber);
                Console.WriteLine("\n      주소 : " + logInCustomer.Adress);

                Console.Write("\n\n\n     휴대폰번호 수정 1, 주소 수정 2, 종료 3 입력 : ");

                inputNumberInString = Console.ReadLine();
                inputNumber = ExceptionHandling.InputNumber(1,3,inputNumberInString);

                if(inputNumber != ExceptionHandling.wrongInput)
                {
                    switch (inputNumber)
                    {
                        case 1:
                            ModifyPhoneNumber(logInCustomer);
                            break;
                        case 2:
                            ModifyAdress(logInCustomer);
                            break;
                        case 3:
                            Console.Clear();
                            isEnd = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void ResisterBook(List<BookInformation> bookList)
        {
            bool isEnd = false;
            BookInformation newBook = new BookInformation();
            string name, author, publisher, quantityInString;
            int quantity;
            while (!isEnd)
            {
                Console.Clear();

                PrintTitle();

                Console.WriteLine("\n      새 도서 등록\n");
                //책정보입력
                Console.WriteLine();
                Console.Write("  도서 이름 : ");
                name = ExceptionHandling.InputString(1, 30);
                if (name == null)
                {
                    Console.WriteLine("잘못된 입력 입니다.");
                    Console.WriteLine("Press Any Key...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine();
                Console.Write("  도서 저자 : ");
                author= ExceptionHandling.InputString(1, 20);

                if (author == null)
                {
                    Console.WriteLine("잘못된 입력 입니다.");
                    Console.WriteLine("Press Any Key...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine();
                Console.Write("도서 출판사 : ");
                publisher = ExceptionHandling.InputString(1, 10);
                if (publisher == null)
                {
                    Console.WriteLine("잘못된 입력 입니다.");
                    Console.WriteLine("Press Any Key...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine();
                Console.Write("      권수 : ");
                quantityInString = Console.ReadLine();
                quantity = ExceptionHandling.InputNumber(1, 10,quantityInString);
                if (quantity == ExceptionHandling.wrongInput)
                {
                    Console.WriteLine("잘못된 입력 입니다.");
                    Console.WriteLine("Press Any Key...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                

                newBook.Name = name;
                newBook.Author = author;
                newBook.Publisher = publisher;
                newBook.Quantity = quantity;

                bookList.Add(newBook);
                Console.WriteLine();

                Console.WriteLine("도서가 등록 됐습니다.");
                Console.WriteLine("Press Any Key...");
                Console.ReadKey();
                Console.Clear();
                isEnd = true;
            }
        }

        public void DeleteBook(List<BookInformation> bookList)
        {
            bool isEnd = false;

            while (!isEnd)
            {

            }
        }

        public void ShowCustomerList(List<CustomerInformation> customerList)
        {
            bool isEnd = false;

            while (!isEnd)
            {

            }
        }

        public void DeleteCustomer(List<CustomerInformation> customerList)
        {
            bool isEnd = false;

            while (!isEnd)
            {

            }
        }
    }
}
