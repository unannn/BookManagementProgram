using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class InputNumberRange        //입력할떄 커서의 위치
    {
        public const int startNumber = 1;
        public const int inputLocationX = 34;
        public const int inputLocationY = 5;
    }
    class User      //초기화면 사용자의 입력값 정의
    {
        public const int logIn = 1;
        public const int createAccount = 2;
        public const int endProgram = 3;
    }

    class UI : CustomerManagement
    {
        public int LogInOrCreateAccount()  //로그인이나 아이디 생성을 위한 초기 화면 출력
        {
            string inputNumberInString = null;
            int inputNumber = -2;
            List<string> initialMenu = new List<string>()
            {
                "로그인 1",
                "회원가입 2",
                "종료 3"
            };

            while(inputNumber < 0) // 올바른 입력시 탈출
            {
                PrintTitle();

                Console.Write($"{initialMenu[0]} {initialMenu[1]} {initialMenu[2]} 입력 : ");
                if(inputNumber == ExceptionHandling.wrongInput)Console.Write("\n다시 입력해 주세요.");

                Console.SetCursorPosition(InputNumberRange.inputLocationX, InputNumberRange.inputLocationY + 1);
                inputNumberInString = Console.ReadLine();

                inputNumber = ExceptionHandling.InputNumber(InputNumberRange.startNumber, initialMenu.Count, inputNumberInString);  //정수입력

                Console.Clear();
            }

            return inputNumber;
        }
        
        public CustomerInformation LoginCustomer(List<CustomerInformation> customerList)  //로그인 함수
        {
            string id = null;
            string password = null;
            CustomerInformation loginCustomer = null;
            int inputInspection = 0;

            while (loginCustomer == null)
            {
                PrintTitle();


                InputIdAndPassword(ref id, ref password, inputInspection);    //아이디와 비밀번호 입력

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

        public CustomerInformation CreateCustomerAccount(List<CustomerInformation> customerList)  //계정생성
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

                if (newAccountException.previousOrStay == "stay")   //n 을 입력시
                {
                    newAccountException.previousOrStay = " ";

                    continue;
                }
                else if (newAccountException.previousOrStay == "previous")  //y 입력시
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

                if (sameIdContinue)    //잘못된 입력 체크
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
              
        public int PrintAdministratorUserMenu()  //관리자 모드일 떄 메뉴 화면
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
        public void PrintAndSerchAndRentBook(List<BookInformation> bookList,CustomerInformation logInCustomer)  //도서 리스트 출력후 검색 또는 대여 화면
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
                            PrintFailMessage("해당 도서가 존재하지 않습니다.");
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
                            PrintFailMessage("해당 도서가 존재하지 않습니다");
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

        private void RentBook(CustomerInformation logInCustomer,List<BookInformation> bookList)  //책대여 함수
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
                        PrintFailMessage("이미 대여한 도서입니다.");

                        return;
                    }
                }

                bookList[inputNumber - 1].Quantity -= 1;
                logInCustomer.RentedBook.Add(bookList[inputNumber - 1]);

                PrintFailMessage("대여가 완료되었습니다.");
            }
            else
            {
                PrintFailMessage("해당 도서가 존재하지 않습니다.");
            }

        }

        public void PrintBookReturn( CustomerInformation logInCustomer, List<BookInformation> bookList)   //대여한 도서를 반납하는함수
        {
            BookManagement bookMangement = new BookManagement();
            string inputNumberInString;
            int inputNumber;
            bool isEnd = false;

            
            while (!isEnd)
            {
                Console.Clear();

                PrintTitle();

                if (logInCustomer.RentedBook.Count == 0)
                {
                    PrintFailMessage("해당 도서가 존재하지 않습니다.");

                    Console.Clear();
                    return;
                }

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

                    PrintFailMessage("반납이 완료 됐습니다.");

                    Console.Clear();
                    isEnd = true;
                }               
            }

        }
        public void ModifyMyData(CustomerInformation logInCustomer)   //고객의 개인정보 수정
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

        public void ResisterBook(List<BookInformation> bookList)   //책 등록, 반복되는 코드 함수화 필요
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
                    PrintFailMessage("잘못된 입력 입니다.");

                    Console.Clear();
                    continue;
                }

                Console.WriteLine();
                Console.Write("  도서 저자 : ");
                author= ExceptionHandling.InputString(1, 20);

                if (author == null)
                {
                    PrintFailMessage("잘못된 입력 입니다.");

                    Console.Clear();
                    continue;
                }

                Console.WriteLine();
                Console.Write("도서 출판사 : ");
                publisher = ExceptionHandling.InputString(1, 10);
                if (publisher == null)
                {
                    PrintFailMessage("잘못된 입력 입니다.");

                    Console.Clear();
                    continue;
                }

                Console.WriteLine();
                Console.Write("      권수 : ");
                quantityInString = Console.ReadLine();
                quantity = ExceptionHandling.InputNumber(1, 10,quantityInString);
                if (quantity == ExceptionHandling.wrongInput)
                {
                    PrintFailMessage("잘못된 입력 입니다.");

                    Console.Clear();
                    continue;
                }
                
                newBook.Name = name;
                newBook.Author = author;
                newBook.Publisher = publisher;
                newBook.Quantity = quantity;

                bookList.Add(newBook);
                Console.WriteLine();

                PrintFailMessage("도서가 등록 됐습니다.");

                Console.Clear();
                isEnd = true;
            }
        }

        public void DeleteBook(List<BookInformation> bookList) //등록되어있는 책들 삭제하는 함수
        {
            string name;

            Console.Clear();

            PrintTitle();

            Console.WriteLine();
            Console.WriteLine("    도서 삭제\n");

            Console.Write(" 삭제할 도서 이름 입력 : ");
            name = ExceptionHandling.InputString(1, 30);
            if(name != null)
            {
                for (int book = 0; book < bookList.Count; book++)
                {
                    if (bookList[book].Name == name)
                    {
                        bookList.RemoveAt(book);
                        Console.WriteLine();

                        PrintFailMessage("해당 도서가 삭제됐습니다.");

                        Console.Clear();
                        return;
                    }
                }
            }
            

            Console.WriteLine();

            PrintFailMessage("해당 도서가 존재하지 않습니다.");

            Console.Clear();
        }

        public void ShowCustomerList(List<CustomerInformation> customerList)
        {
            Console.SetWindowSize(130, 36);

            Console.Clear();

            PrintTitle();

            Console.WriteLine();
            Console.WriteLine("      회원 목록\n");

            PrintAllCustomer(customerList);

            Console.WriteLine();
            Console.WriteLine("Press Any Key...");
            Console.ReadKey();
            Console.Clear();

            Console.SetWindowSize(90, 36);
        }

        public void DeleteCustomer(List<CustomerInformation> customerList,CustomerInformation logInCustomer)
        {
            string inputId = null;
            PrintTitle();

            Console.WriteLine();
            Console.Write("      회원 아이디 입력 : ");
            inputId = ExceptionHandling.InputString(1,11);
            if(inputId != null)
            {
                if(logInCustomer.IsAdministrator != true)
                {
                    for (int customer = 0; customer < customerList.Count; customer++)
                    {
                        if (customerList[customer].Id == inputId)
                        {
                            customerList.RemoveAt(customer);

                            PrintFailMessage("해당 아이디가 삭제 됐습니다.");
                            Console.Clear();
                            return;
                        }
                    }
                    PrintFailMessage("해당 아이디가 없습니다.");
                }
                else
                {
                    PrintFailMessage("관리자의 아이디 입니다.");               
                }
            }
            
            Console.Clear();
        }
    }
}
