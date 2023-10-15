using Downloader.Enums;

namespace Downloader.Functions
{
    public static class ConsoleHelper
    {
        public static void Write(this string text, WritingSpeed speed = WritingSpeed.VeryFast)
        {
            text.Write(ConsoleColor.White, speed);
        }

        public static void Write(this string text, ConsoleColor color, WritingSpeed speed = WritingSpeed.VeryFast, string suffix = "", bool moveNewLineBeforeWriting = false, bool moveNewLineAfterWriting = false)
        {
            char[] characters;

            if (!string.IsNullOrEmpty(suffix))
            {
                text = $"{text + suffix}";
            }

            if (moveNewLineBeforeWriting)
            {
                MoveCursorY(1);
                SetCursorPositionX(0);
            }

            characters = text.ToArray();

            foreach (char character in characters)
            {
                Console.ForegroundColor = color;
                Console.Write(character);
                Thread.Sleep((int)speed);
            }

            if (moveNewLineAfterWriting)
            {
                MoveCursorY(1);
                SetCursorPositionX(0);
            }

            Console.ResetColor();
        }

        public static void WriteInfo(this string text, WritingSpeed speed = WritingSpeed.VeryFast)
        {
            text.Write(ConsoleColor.Green, speed);
        }

        public static void WriteError(this string text, WritingSpeed speed = WritingSpeed.VeryFast, bool moveNewLineAfterWriting = false)
        {
            text.Write(ConsoleColor.Red, speed, moveNewLineAfterWriting: moveNewLineAfterWriting);
        }

        public static void WriteWarn(this string text, WritingSpeed speed = WritingSpeed.VeryFast)
        {
            text.Write(ConsoleColor.Yellow, speed);
        }

        public static void WriteQuestion(this string text, WritingSpeed speed = WritingSpeed.VeryFast)
        {
            text.Write(ConsoleColor.DarkYellow, speed);
        }

        public static void MoveCursor(int movementX, int movementY)
        {
            int xPosition = Console.CursorLeft;
            int yPosition = Console.CursorTop;

            Console.CursorVisible = false;
            Console.SetCursorPosition(xPosition + movementX, yPosition + movementY);
            Console.CursorVisible = true;
        }

        public static void MoveCursorX(int movementX)
        {
            MoveCursor(movementX, 0);
        }

        public static void MoveCursorY(int movementY)
        {
            MoveCursor(0, movementY);
        }

        public static void SetCursorPosition(int xPosition, int yPosition)
        {
            Console.SetCursorPosition(xPosition, yPosition);
        }

        public static void SetCursorPositionX(int xPosition)
        {
            int currentYPosition = Console.CursorTop;

            SetCursorPosition(xPosition, currentYPosition);
        }

        public static void SetCursorPositionY(int yPosition)
        {
            int currentXPosition = Console.CursorLeft;

            SetCursorPosition(currentXPosition, yPosition);
        }

        public static string ReadLine()
        {
            string line = string.Empty;
            string cleanLine = string.Empty;

            Console.ForegroundColor = ConsoleColor.White;

            line = Console.ReadLine() ?? line;
            cleanLine = line.Trim();

            return cleanLine;
        }

        public static bool IsContinue()
        {
            bool isContinue;
            ConsoleKeyInfo keyInfo;

            isContinue = false;
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key != ConsoleKey.Escape)
            {
                isContinue = true;
            }

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            return isContinue;
        }

        public static void ClearCurrentLine()
        {
            int yPosition = Console.CursorTop;

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, yPosition);
        }

        public static void PercentageCallback(dynamic percentage)
        {
            double percentageValue;

            Console.CursorVisible = false;

            if (Double.TryParse(percentage.ToString(), out percentageValue))
            {
                percentageValue = double.Parse(percentage.ToString());
                percentageValue = Math.Round(percentageValue);

                WriteInfo($"%{percentageValue,-3}");

                if (percentageValue != 100)
                {
                    MoveCursorX(-4);
                }
            }
            else
            {
                WriteInfo($"{percentage.ToString(),-3}");
                MoveCursorX(-3);
            }
        }

        public static void SuccessCallback(dynamic message)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.CursorVisible = true;
        }

        public static void ErrorCallback(dynamic message)
        {
            Write(message, ConsoleColor.Red, speed: WritingSpeed.UltraFast, moveNewLineAfterWriting: true);
        }
    }
}
