using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class NewAccountException
    {
        public bool sameId;
        public bool wrongId;
        public bool wrongPassword;
        public bool wrongName;
        public bool wrongPhoneNumber;
        public bool wrongAdress;
        public string previousOrStay;

        public NewAccountException()
        {
            sameId = false;
            wrongId = false;
            wrongPassword = false;
            wrongName = false;
            wrongPhoneNumber = false;
            wrongAdress = false;
            previousOrStay = " ";
        }
        public void initialize(bool trueOrFalse)
        {
            sameId = trueOrFalse;
            wrongId = trueOrFalse;
            wrongPassword = trueOrFalse;
            wrongName = trueOrFalse;
            wrongPhoneNumber = trueOrFalse;
            wrongAdress = trueOrFalse;
            previousOrStay = " ";
        }
    }
   
    static class ExceptionHandling
    {
        public const int wrongInput = -1;
        //public const string wrongInputString = null;

        static public int InputNumber(int  start, int end, string numberInString)   //start 와 end 사이에 문자열이 입력되면 정수로 변환 후 반환 실패시 -1 반환
        {
            int number;

            if (!string.IsNullOrEmpty(numberInString) && numberInString.Length == 1)
            {
                if (string.Compare(numberInString, start.ToString()) >= 0 && string.Compare(numberInString, end.ToString()) <= 0)
                {
                    number = int.Parse(numberInString);

                    return number;
                }                
            }

            return wrongInput;
        }

        static public string InputYesOrNo(string yesOrNo)   //문자열이 y 인지 n인지 아님 다른값이 들어왔는지 판단 후 반환
        {

            if (!string.IsNullOrEmpty(yesOrNo) && yesOrNo.Length == 1)
            {
                if (string.Compare(yesOrNo, "y") == 0)
                {
                    return yesOrNo;
                }
                else if(string.Compare(yesOrNo,"n") == 0)
                {
                    return yesOrNo;
                }

            }

            return null;
        }

        static public string InputId()   //id입력 예외처리
        {
            string id = null;

            id = Console.ReadLine();

            if (!string.IsNullOrEmpty(id) && id.Length >= 2 && id.Length <= 11)       //두 글자 이상 열한글자 이하이고
            {
                if(!id.Contains(" "))            //띄어쓰기가 없어야 함
                {
                    return id;
                }
            }

            return null;
        }

        static public string InputPassword()   //id입력 예외처리
        {
            string password = null;

            password = Console.ReadLine();

            if (!string.IsNullOrEmpty(password) && password.Length >= 2 && password.Length <= 11)       //두 글자 이상이고
            {
                if (!password.Contains(" "))            //띄어쓰기가 없어야 함
                {
                    return password;
                }
            }

            return null;
        }

        static public string InputPhoneNumber()
        {
            string phoneNumber;
            int number;

            phoneNumber = Console.ReadLine();

            if(phoneNumber.Length == 11)
            {

                for (number = 0; number < 11; number++)
                {
                    if (phoneNumber[number] < '0' || phoneNumber[number] > '9')
                    {
                        break;
                    }
                }

                if (number != 11) phoneNumber = null;
            }
            else
            {
                phoneNumber = null;
            }

            return phoneNumber;   
            
            //while(phoneNumber.Length < 11)
            //{
            //    input = Console.Read();

            //    if (input >= '0' && input <= '9')
            //    {
            //        phoneNumber += Convert.ToChar(input);
            //    }
            //    else
            //    {
            //        phoneNumber = null;
            //        break;
            //    }
            //}


        }

        static public string inputString(int above, int below)
        {
            string inputString = null;
                      

            inputString = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputString) && inputString.Length >= above && inputString.Length <= below)       // above 이상 below 이하의 길이 일때
            {
                return inputString;
            }

            return null;

        }
    }
}
