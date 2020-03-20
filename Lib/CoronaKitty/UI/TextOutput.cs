using System;
using System.Collections.Generic;

namespace CoronaKitty.UI

/*

    This handles basic text output with varying background and foreground colours

*/
{

    public struct TextData
    {
        public String text; //text to be output
        public ConsoleColor FG; //text foreground colour
        public ConsoleColor BG; //text background colour

        public TextData(string str, ConsoleColor fg, ConsoleColor bg) {

            text = str;
            FG = fg;
            BG = bg;
            
        }
    }

    public class TextOutput
    {

        public static ConsoleColor CONSOLEBG = ConsoleColor.Black;

        public static void Put(String text, ConsoleColor FG , ConsoleColor BG) {

            Console.ForegroundColor = FG;
            Console.BackgroundColor = BG;

            Console.WriteLine(text);
            Console.ResetColor();

        }

        //prints out a TextData struct
        public static void Put(TextData data) {

            Console.ForegroundColor = data.FG;
            Console.BackgroundColor = data.BG;
            Console.WriteLine(data.text);
            Console.ResetColor();

        }

        //outputs a list of TextData objects with each object being printed on a new line
        public static void PutLines(List<TextData> lines) {

            foreach (TextData line in lines) {

                Put(line);

            }

        }

        public static void PutLine(List<TextData> substrings) {

            foreach (TextData substring in substrings) {

                Console.ForegroundColor = substring.FG;
                Console.BackgroundColor = substring.BG;
                Console.Write(substring.text);
                Console.ResetColor();

            }

            Console.Write("\n");

        }

    }
}