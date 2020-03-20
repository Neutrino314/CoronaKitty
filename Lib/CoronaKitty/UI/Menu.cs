using System;
using System.Collections.Generic;
using System.Linq;

namespace CoronaKitty.UI

{
    public class Menu
    {

        private TextData m_title; //text data object for displaying the title
        private TextData m_menuText; //text data object for displaying the menu text
        private TextData m_optionFormatting; //holds the way the options will be formatted
        //when providing this data the text should be provided in this format: "@) " where '@' is the option
        private TextData m_optionTextFormatting; //text does not matter however the colours do!!!
        private bool m_optionsType = false; //if false then options are numbered else, options are prefaced with letters
        private string m_optionSelected; //option selected by the user

        private List<string> m_options = new List<string>(); //the list of options available to choose from

        public Menu() { //default constructor

            m_optionFormatting.text = "@)";

        }
        public Menu(Menu rhs) : this(rhs.m_options, rhs.m_optionTextFormatting, rhs.m_optionsType, rhs.m_title, rhs.m_menuText, rhs.m_optionFormatting) {

        }

        public Menu(List<string> options, TextData optionTextFormatting, bool optionType, TextData title, TextData menuText, TextData optionFormatting) {

            if (options.Count == 0) {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error!!!! No options were provided!!!");
                Console.ResetColor();
                Environment.FailFast("");

            }

            m_options = options;
            m_optionFormatting = optionFormatting;

            if (optionFormatting.text == "") {

                optionFormatting.text = "@)";

            }
            m_optionTextFormatting = optionTextFormatting;
            m_title = title;
            m_menuText = menuText;
            m_optionsType = optionType;

        }

        private string generateOptionString(string optionOridnal) {

            string option;

            char[] delim = {'@'};

            string[] splitOption = m_optionFormatting.text.Split(delim);

            option = splitOption[0] + optionOridnal + splitOption[1];

            return option;

        }

        public string execute() {

            List<TextData> option = new List<TextData>();
            option.Add(new TextData("", m_optionFormatting.FG, m_optionFormatting.BG));
            option.Add(m_optionTextFormatting);

            while (true) {

                if (m_title.text != "") {

                    TextOutput.Put(m_title);

                }
                if (m_menuText.text != "") {

                    TextOutput.Put(m_menuText);

                }

                Console.WriteLine("");

                for (int i = 0; i < m_options.Count; i++) {

                    if (m_optionsType) {

                        option[0] = new TextData(generateOptionString(((char)i).ToString()), m_optionFormatting.FG, m_optionFormatting.BG);

                    } else {

                        option[0]= new TextData(generateOptionString((i + 1).ToString()), m_optionFormatting.FG, m_optionFormatting.BG);

                    }

                    option[1] = new TextData(m_options[i], m_optionTextFormatting.FG, m_optionTextFormatting.BG);

                    TextOutput.PutLine(option);
                    Console.BackgroundColor = TextOutput.CONSOLEBG;

                }

                m_optionSelected = Console.ReadLine();

                if (m_optionSelected.Any(c => char.IsDigit(c)) && m_optionsType) {

                    TextOutput.Put("Selected option invalid. Please Try again!", ConsoleColor.Red, Console.BackgroundColor);
                    continue;

                } else if (m_optionSelected.Any(c => char.IsLetter(c)) && !m_optionsType) {

                    TextOutput.Put("Selected option invalid. Please Try again!", ConsoleColor.Red, Console.BackgroundColor);
                    continue;

                } else {

                    return m_optionSelected;

                }

            }

        }

    }
}