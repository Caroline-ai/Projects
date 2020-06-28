
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;



namespace Wisielec
{
    class Program
    {
        static void Main()
        {
            
            
            //Console.WriteLine("Wisielec wersja alpha");
            if (!File.Exists(@".\dictionary.txt"))
            {
                File.Create(@".\dictionary.txt");
            }


            Console.WriteLine("Wisielec");
            Console.WriteLine("");
            Console.WriteLine("Wybierz opcję:");
            do
            {
                PrintChoose();
                int action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        Console.Clear();
                        Game();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Edycja słownika");
                        Edit();
                        break;
                }
            }
            while (true);
        }
        private static void PrintChoose()
        {
             Console.WriteLine("1 - Rozpocznij grę");
             Console.WriteLine("2 - Edytuj słownik");
        }

        private static void Game()
        {

          Regex wincheck = new Regex("^(♦)+$");

         
            Console.WriteLine("Witaj w grze.");
            Console.WriteLine("Note: Hasło wpisujemy z znakami specjalnymi(jesli takie występują)");

            if (new FileInfo(@"..\..\..\dictionary.txt").Length < 1)
            {
                Console.ForegroundColor = (ConsoleColor)12;
                Console.WriteLine("Słownik jest pusty!");
                Console.ResetColor();

                Console.WriteLine("Wciśnij Enter by wrócić do menu startowego ");
                Console.ReadLine();
                Console.Clear();
                Main();
            }
            string[] lines = File.ReadAllLines(@"..\..\..\dictionary.txt");

            Random rand = new Random();

            
            string SelectedWord = lines[rand.Next(lines.Length)];
            
            string CurrentWord = SelectedWord.ToLower();
            CurrentWord = Regex.Replace(CurrentWord, "[^a-zA-Z0-9żółćęśąźń]", "♦");
            
            int visred = 0;
            List<char> replet = new List<char>(); //repeated letters


            for (int miss = 0; miss < 7;)
            {
            Ask:
                switch (miss)
                {
                    case 1:
                        Console.WriteLine("    _____________");
                        Console.WriteLine("    -----------\\|");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("_______________||");
                        break;
                    case 2:
                        Console.WriteLine("    _____________");
                        Console.WriteLine("    -----------\\|");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("     (X  x)    ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("_______________||");
                        break;
                    case 3:
                        Console.WriteLine("    _____________");
                        Console.WriteLine("    -----------\\|");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("     (X  x)    ||");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("_______________||");
                        break;
                    case 4:
                        Console.WriteLine("    _____________");
                        Console.WriteLine("    -----------\\|");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("     (X  x)    ||");
                        Console.WriteLine("  _____|       ||");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("_______________||");
                        break;
                    case 5:
                        Console.WriteLine("    _____________");
                        Console.WriteLine("    -----------\\|");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("     (X  x)    ||");
                        Console.WriteLine("  _____|_____  ||");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("_______________||");
                        break;
                    case 6:
                        Console.WriteLine("    _____________");
                        Console.WriteLine("    -----------\\|");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("     (X  x)    ||");
                        Console.WriteLine("  _____|_____  ||");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("       |       ||");
                        Console.WriteLine("      /        ||");
                        Console.WriteLine("     /         ||");
                        Console.WriteLine("    /          ||");
                        Console.WriteLine("               ||");
                        Console.WriteLine("_______________||");
                        break;

                    default:
                        for (int i = 0; i < 12; i++)
                        {
                            Console.WriteLine("");
                        }
                        break;
                }
             
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
                        Console.WriteLine("Podaj literę lub odgadnij hasło:");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ResetColor();
                        Console.WriteLine("Podaj literę lub odgadnij hasło:");
                        break;

                }
                string inputletter = Console.ReadLine();
                if (inputletter.Equals(SelectedWord, StringComparison.OrdinalIgnoreCase))
                {
                    CurrentWord = Regex.Replace(CurrentWord, "[a-zA-Z0-9żółćęśąźń]", "♦");
                }
                else
                {
                    if (Regex.IsMatch(inputletter, @"^[\p{L}]+$") && inputletter.Length == 1)
                    {
                        visred = 0;
                        char CurrentLetter = Convert.ToChar(inputletter.ToLower());
                        if (!replet.Contains(CurrentLetter))
                        {
                            replet.Add(CurrentLetter);
                            if (CurrentWord.IndexOf(CurrentLetter) != -1)
                            {
                                CurrentWord = CurrentWord.Replace(CurrentLetter, '♦'); //mark all letters matching input (case insensitive)
                            }
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
                }
                Console.Clear();
                if (wincheck.IsMatch(CurrentWord)) //check if all letters were guessed
                {
                    Console.ForegroundColor = (ConsoleColor)10; //green
                    Console.WriteLine("Wygrana :)");
                    Console.ResetColor();
                    Console.WriteLine(SelectedWord);

                    Console.WriteLine("Wciśnij Enter by wrócić do menu startowego ");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
            }
               Console.WriteLine("    _____________");
               Console.WriteLine("    -----------\\|");
               Console.WriteLine("       |       ||");
               Console.WriteLine("     (X x)     ||");
               Console.WriteLine("  _____|_____  ||");
               Console.WriteLine("       |       ||");
               Console.WriteLine("       |       ||");
               Console.WriteLine("      / \\      ||");
               Console.WriteLine("     /   \\     ||");
               Console.WriteLine("    /     \\    ||");
               Console.WriteLine("               ||");
               Console.WriteLine("_______________||");
               Console.ForegroundColor = (ConsoleColor)12;
               Console.WriteLine("Przegrana :(");
               Console.ResetColor();
               Console.WriteLine(SelectedWord);

               Console.WriteLine("Wciśnij Enter by wrócić do menu startowego ");
               Console.ReadLine();
               Console.Clear();
               Main();
        }
    
        private static void Edit()
        {
            Console.WriteLine("Edytor");
            Console.WriteLine("Wybier opcje:");
            Console.WriteLine(" ");
            Console.WriteLine("1 - Dodaj słowo/zdanie do słownika");
            Console.WriteLine("2 - Wyczyść słownik");
            int editel = int.Parse(Console.ReadLine());
            

            switch (editel)
            {
                case 1:
                    Console.WriteLine("Wpisz słowo/zdanie do dodania.");
                    string newword = Console.ReadLine();
                    if (newword.Contains("♦"))
                    {
                        newword = newword.Replace('♦', ' ');
                    }
                    File.AppendAllText(@"..\..\..\dictionary.txt", newword + Environment.NewLine);
                    Console.WriteLine("Słowo/zdanie zostało dadane do słownika");
                    
                    Console.WriteLine("Wciśnij Enter by wrócić do menu startowego ");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                    break;

                case 2:
                    File.WriteAllText(@"..\..\..\dictionary.txt", string.Empty);
                    Console.Clear();
                    Console.WriteLine("Słownik został wyczyszczony");
                   
                    Console.WriteLine("Wciśnij Enter by wrócić do menu startowego ");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                    break;
            }
            
        }
       
    }
}

    


