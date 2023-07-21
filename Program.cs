using System;
using System.Collections.Generic;

public class ScrabbleScore
{ 
    public static int Score(string? input)
    {
        int scrabbleScore = 0;

        Dictionary<int, List<char>> letterScore = new Dictionary<int, List<char>>()
        {
            {1, new List<char>() { 'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'}},
            {2, new List<char>() {'D', 'G' }},
            {3, new List<char>() { 'B', 'C', 'M', 'P' }},
            {4, new List<char>() { 'F', 'H', 'V', 'W', 'Y' }},
            {5, new List<char>() { 'K' }},
            {8, new List<char>() { 'J', 'X' }},
            {10, new List<char>() { 'Q', 'Z' }}
        }; 
        
        foreach(char c in input)
        {
            foreach(KeyValuePair<int, List<char>> charToMatch in letterScore)
            {
                if(charToMatch.Value.Exists(x => x == Char.ToUpper(c)))
                {
                    scrabbleScore += charToMatch.Key;
                }
            }
        }
    return scrabbleScore;
    }

    public static bool InputValidity (string input)
    {   
        if(string.IsNullOrWhiteSpace(input) || input.Any(c => !char.IsLetter(c)))
        {
            Console.WriteLine("\n" + input + " is not valid. Please Enter a valid text\n");
            return false;
        }
        else
        {
            return true;
        }
    }

    public static void Main(String[] args)
    {
    string userGuess;
    
    do{
    Console.WriteLine("Enter A Word:");
    userGuess = Console.ReadLine();      
    }while(!InputValidity(userGuess));

    Console.WriteLine(Score(userGuess));
    }
}