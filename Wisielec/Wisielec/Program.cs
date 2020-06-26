
using System;
using System.Text.RegularExpressions;



namespace Wisielec
{
    class Program
    {
        static void Main()
        {
            Regex wincheck = new Regex("^(♦)+$");
            //Console.WriteLine("Wisielec wersja pre-alpha");
            //Console.WriteLine("");
            //Console.WriteLine("Wybierz opcję:");
            //Console.WriteLine("1. Rozpocznij grę");
            //Console.WriteLine("2. Edytuj słownik");
            //Console.WriteLine("");
            //Console.WriteLine("Wybrana opcja:");
            //int MainMenuSelection = int.Parse(Console.ReadLine());
            Start:
            Console.WriteLine("Witaj w grze w wisielca.");
            string SelectedWord = "Słowo";
            string CurrentWord = SelectedWord.ToLower();
            int visred = 0;

            for (int miss = 0; miss < 7;)
            {
            Ask:
                Console.WriteLine(miss);
                for (int wordlen = 0; wordlen < SelectedWord.Length; wordlen++)
                {
                    if (CurrentWord[wordlen] == '♦')  //check if letter should be visible
                    {
                        Console.Write(SelectedWord[wordlen]); //visible letters
                    }
                    else
                    {
                        if (CurrentWord[wordlen] == ' ')
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.Write("_"); //hidden letters
                        }




                    }
                }
                Console.WriteLine();

                switch (visred)
                {
                    case 1:
                        Console.ForegroundColor = (ConsoleColor)12;
                        Console.WriteLine("Podaj literę:");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ResetColor();
                        Console.WriteLine("Podaj literę:");
                        break;

                }
                string inputletter = Console.ReadLine();
                if (Regex.IsMatch(inputletter, @"^[\p{L}]+$") && inputletter.Length == 1)
                {
                    visred = 0;
                    char CurrentLetter = Convert.ToChar(inputletter.ToLower());
                    if (CurrentWord.IndexOf(CurrentLetter) != -1)
                    {
                        CurrentWord = CurrentWord.Replace(CurrentLetter, '♦'); //mark all letters matching input (case insensitive)
                    }
                    else
                    {
                        miss += 1; //increase wrong answer counter 

                    }
                }
                else
                {
                    visred = 1;
                    Console.Clear();
                    goto Ask;
                };

                Console.Clear();
                if (wincheck.IsMatch(CurrentWord)) //check if all letters were guessed
                {
                    Console.ForegroundColor = (ConsoleColor)10;
                    Console.WriteLine("Wygrana :)");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    goto Start;

                }
            }
            Console.ForegroundColor = (ConsoleColor)12;
            Console.WriteLine("Przegrana :(");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            goto Start;
        }
    }
}

    


