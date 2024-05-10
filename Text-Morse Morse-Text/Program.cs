using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static Dictionary<char, string> _morseAlphabetDictionary;
    private static Dictionary<string, char> _reverseMorseAlphabetDictionary;

    static void Main(string[] args)
    {
        InitializeDictionary();

        while (true)
        {
            Console.WriteLine("Text to Morse Code/Morse Code to Text by Andrei Emilian Rachita - andrei(at)rachita(dot)net");
            Console.WriteLine("==============================================================================================");
            Console.WriteLine("");
            Console.Write("Select option: \n1. Text to Morse code \n2. Morse code to Text \n");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the message: ");
                    string userInput = Console.ReadLine();
                    string morseCode = ConvertTextToMorseCode(userInput.ToUpper());
                    Console.WriteLine("Morse Code: " + morseCode);
                    break;

                case 2:
                    Console.Write("Enter the Morse code: ");
                    string morseInput = Console.ReadLine();
                    string text = ConvertMorseCodeToText(morseInput);
                    Console.WriteLine("Text: " + text);
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            Console.Write("Do you want to enter a new query? (y/n): ");
            string continueResponse = Console.ReadLine().ToLower();
            if (continueResponse != "y")
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
            Console.Clear();
        }
    }

    private static void InitializeDictionary()
    {
        _morseAlphabetDictionary = new Dictionary<char, string>()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
            {'Z', "--.."}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
            {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."},
            {'0', "-----"}, {' ', "/"}
        };

        _reverseMorseAlphabetDictionary = _morseAlphabetDictionary.ToDictionary(x => x.Value, x => x.Key);
    }

    private static string ConvertTextToMorseCode(string input)
    {
        return string.Join(" ", input.Select(c => _morseAlphabetDictionary.ContainsKey(c) ? _morseAlphabetDictionary[c] : ""));
    }

    private static string ConvertMorseCodeToText(string input)
    {
        return string.Join("", input.Split(' ').Select(s => _reverseMorseAlphabetDictionary.ContainsKey(s) ? _reverseMorseAlphabetDictionary[s].ToString() : ""));
    }
}
