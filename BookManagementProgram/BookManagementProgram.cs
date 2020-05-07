﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookManagementProgram
    {
        public void StartProgram()
        {
            Console.Title = "BookManagementProgram";
            Console.SetWindowSize(70,36);

            List<BookInformation> bookList = new List<BookInformation>() {
                new BookInformation("투명 드래곤","이윤환","한빛미디어",5),
                new BookInformation("어쩌구일찐짱 1","김일진","퍼스트북",2),
                new BookInformation("어쩌구일찐짱 2","김일진","퍼스트북",2),
            };
            List<CustomerInformation> customerList = new List<CustomerInformation>()
            {
                new CustomerInformation("digh7930","16011679","이윤환","01049075608","서울시 도봉구 방학3동 신동아아파트",true) //생성자 만들고 로그인 해보기
            };
            CustomerInformation logInCustomer = null, createdAccount;
            UI ui = new UI();
            int selectedNumber = ExceptionHandling.wrongInput;
            bool loginSucessful = false;
            bool endOfProgram = false;
            
            while (!endOfProgram)
            {
                while (!loginSucessful)            //로그인 성공 시 까지 반복
                {
                    selectedNumber = ui.LogInOrCreateAccount();

                    if (selectedNumber == User.logIn)
                    {
                        logInCustomer = ui.LoginCustomer(customerList); //뒤로가기

                        if (logInCustomer == null) continue;
                        else loginSucessful = true;
                    }
                    else if (selectedNumber == User.createAccount)
                    {
                        createdAccount = ui.CreateCustomerAccount(customerList);

                        if (createdAccount == null) continue;  //뒤로가기

                        customerList.Add(createdAccount);
                    }
                }

                selectedNumber = ExceptionHandling.wrongInput; //seletedNumber 다시 초기화
                
                if(logInCustomer.IsAdministrator == true)
                {
                    while (true)
                    {
                        selectedNumber = ui.PrintAdministratorUserMenu();

                        switch (selectedNumber)
                        {
                            case 1:
                                ui.RentBook(logInCustomer, bookList);
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
                            case 8:
                                break;
                            case 9:
                                break;

                        }
                        
                    }
                }
                else
                {
                    while (true)
                    {
                        selectedNumber = ui.PrintUserMenu();
                    }
                }
            }
            

            
        }
    }
}
