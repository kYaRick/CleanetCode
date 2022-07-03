using System;
using static System.Console;

using kYaCleanNETCode;

namespace TypesBranchesAndLoops
{
    class Program
    {
        //Configuration block:
        private static string s_ChatPrefix = "[MysteryNumber]";
        private static sbyte s_AttemptsNum = -1;                                  // "-1" it is give infinity attempts for user.
        private static ushort s_MinRND = 0;
        private static ushort s_MaxRND = 999;
        private static string s_ProgramPrefix = "[Program]";
        private static string s_UserPrefix = "[User]";
        //~> end configuration block//
        
        private static string? userName;
        public static string? UserName { 
            get
            {
                if (string.IsNullOrWhiteSpace(userName))
                {
                    return $"{_ProgramPrefix} username didn't install";
                }
                else
                {
                    return userName;
                }
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    userName = "";
                } 
                else
                {
                    _UserPrefix = '[' + value + ']';
                    userName = value;
                }
            } }

        public static void Main()
        {
            var isContinue = false;

            WriteLine($"{_ProgramPrefix} Enter Your name, please. (\"Enter\" for skip)");
            Write($"{_UserPrefix} ");
            UserName = ReadLine();

            do
            {
                var mn = new MysteryNumber(_ChatPrefix, _AttemptsNum);
                mn.GetRandomInScope(_MinRND, _MaxRND);
                bool isUserWin = false;
                while ((mn.AttemptsNum > 0 || mn.AttemptsNum == -1) && !isUserWin)
                {
                    Write($"{_UserPrefix} [{mn.AttemptsNum}\\{_AttemptsNum}] Enter Your num: ");

                    ushort.TryParse(ReadLine(), out ushort inputNum);
                    isUserWin = mn.TryToGuess(inputNum);
                }

                WriteLine($"{_ProgramPrefix} So...\n\t1 - start over\n\t0 - exit");
                Write($"{_UserPrefix}");
                var keyCode= ReadKey().Key;
                switch (keyCode)
                {
                    case ConsoleKey.D1:
                        {
                            isContinue = true;  
                            Clear();
                        }break;
                    default:
                        {
                            isContinue = false;
                            WriteLine($"{_ProgramPrefix} Bye, {UserName}!");
                        }
                        break;
                }
            } while (isContinue);
            ReadKey();
        }
    }
}