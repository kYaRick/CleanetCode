using System;
using static System.Console;

using kYaCleanNETCode;

namespace TypesBranchesAndLoops
{
    class Program
    {
        //Configuration block:
        private static string _ChatPrefix = "[MysteryNumber]";
        private static sbyte _AttemptsNum = 5;
        private static ushort _MinRND = 1;
        private static ushort _MaxRND = 3;
        private static string _ProgramPrefix = "[Program]";
        private static string _UserPrefix = "[User]";
        //
        
        private static string? userName;
        public static string? UserName { 
            get
            {
                if (string.IsNullOrWhiteSpace(userName))
                {
                    return "User name didn't install";
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

            WriteLine($"{_ProgramPrefix} Enter You name, please. (\"Enter\" for skip)");
            Write($"{_UserPrefix} ");
            UserName = ReadLine();

            do
            {
                var mn = new MysteryNumber(_ChatPrefix, _AttemptsNum);
                mn.GetRandomInScope(_MinRND, _MaxRND);
                bool isUserWin = false;
                while ((mn.AttemptsNum > 0 || mn.AttemptsNum == -1) && !isUserWin)
                {
                    Write($"{_UserPrefix} [{mn.AttemptsNum}\\{_AttemptsNum}] Enter You num: ");

                    ushort.TryParse(ReadLine(), out ushort inputNum);
                    isUserWin = mn.TryToGuess(inputNum);
                }

                WriteLine("So...\n\t1 - start over\n\t0 - exit");
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
                            WriteLine($"Bye {UserName}!");
                        }
                        break;
                }
            } while (isContinue);
            ReadKey();
        }
    }
}