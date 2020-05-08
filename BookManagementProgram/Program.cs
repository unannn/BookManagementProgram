using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class Program
    {
        //1 입력후 아이디 asdf 비밀번호 asdf 입력하면 관리자모드로 로그인
        static void Main(string[] args)
        {
            BookManagementProgram bookManagementProgram = new BookManagementProgram();
            bookManagementProgram.StartProgram();
        }
    }
}
