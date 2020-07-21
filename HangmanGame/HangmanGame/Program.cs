using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");

            String[] listOfWords = new string[5];
            listOfWords[0] = "aeroplane";
            listOfWords[1] = "banana";
            listOfWords[2] = "caterpillar";
            listOfWords[3] = "door";
            listOfWords[4] = "elephant";

            Random randomWordPicker = new Random();
            int wordPosition = randomWordPicker.Next(0, 4);

            String chosenWord = listOfWords[wordPosition];

            int lives = chosenWord.Length + 3;

            Console.WriteLine("\nYou have " + lives + " lives/life left.");
            Console.WriteLine("\nEnter a guess: ");

            char[] hidden = new char[chosenWord.Length];

            for (int i = 0; i < chosenWord.Length; i++)
            {
                hidden[i] = '*';
            }

            bool status = true;

            while (status)
            {
                char userGuess = Console.ReadLine()[0];

                bool noHidden = false;
                bool match = false;

                for (int j = 0; j < chosenWord.Length; j++)
                {
                    if (userGuess == chosenWord[j])
                    {
                        match = true;
                        hidden[j] = userGuess;
                    }
                }

                if (match == false)
                {
                    lives--;
                }

                Console.WriteLine("\nYou have " + lives + " lives/life left.");
                Console.WriteLine("\n");

                for (int k = 0; k < chosenWord.Length; k++)
                {
                    Console.Write(hidden[k]);
                }

                if (lives == 0)
                {
                    status = false;
                }

                Console.WriteLine("\n");
            }
        }
    }
}
