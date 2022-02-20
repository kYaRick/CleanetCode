using System;
using static System.Console;

namespace kYaCleanNETCode
{
    public class MysteryNumber
    {
        public sbyte AttemptsNum { get; private set; } = 3;
        
        private readonly string _ChatPrefix = "[MysteryNumber]";
        private ushort _GivenNum = 42;

        public MysteryNumber(){}
        public MysteryNumber(string chatPrefix, sbyte attemptsNum)
        {
            _ChatPrefix = chatPrefix;
            AttemptsNum = attemptsNum;
        }

        public ushort GetRandomInScope(ushort min, ushort max, bool isShowMessage = true)
        {
            if (isShowMessage)
            {
                WriteLine($"{_ChatPrefix} I'm thinking of a number between {min} and {max}...");
                WriteLine($"{_ChatPrefix} Try to think what number I'm thinking of?");
            }

            return _GivenNum = (ushort)new Random().Next(min, ++max);
        }
        public bool TryToGuess(ushort inputNum, bool isShowMessage = true) 
        {
            bool isUserWin = false;

            if (AttemptsNum > 0 || AttemptsNum != -1)
            {
                if (inputNum == _GivenNum)
                {
                    isUserWin = true;
                    if (isShowMessage)
                    {
                        WriteLine($"{_ChatPrefix} Welcome! You won!");
                    }
                }
                else
                {
                    if (isShowMessage)
                    {
                        WriteLine($"{_ChatPrefix} So... {inputNum} it's not bad, but... This is mistake");
                    }
                }
            } 
            else
            {
                WriteLine($"{_ChatPrefix} Your attempts are over");
            }

            AttemptsNum--;
            return isUserWin;
        }
    }
}
