using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DayTwo : MonoBehaviour
{
    public enum Play
    {
        Rock,
        Paper,
        Scissors
    }   
    
    Dictionary<string,Play> plays = new Dictionary<string, Play>()
    {
        {"A", Play.Rock},
        {"B", Play.Paper},
        {"C", Play.Scissors},
        {"X", Play.Rock},
        {"Y", Play.Paper},
        {"Z", Play.Scissors}
    };

    private int totalScore;

    private void Start()
    {
        
        var games = GetFileContents();
        
        totalScore = 0;
        foreach (var game in games)
        {
          totalScore += CalculateScoresOfGame(game.Split(' '));
        }
        
        Debug.Log("Total Score: " + totalScore);
    }

int CalculateScoresOfGame(string[] game)
    {
        int score = 0;
      //convert each score to a play
        var playerOnePlay = plays[game[0]];
        var playerTwoPlay = plays[game[1]];

        switch (playerTwoPlay)
        {
            case Play.Rock:
                score += 1;
                break;
            case Play.Paper:
                score += 2;
                break;
            case Play.Scissors:
                score += 3;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        
//compare the plays, if the second player wins add 6 to the score, if its a draw add 3, if the second player loses, dont add anything
        if (playerOnePlay == Play.Rock && playerTwoPlay == Play.Paper)
        {
            score += 6;
        }
        else if (playerOnePlay == Play.Paper && playerTwoPlay == Play.Scissors)
        {
            score += 6;
        }
        else if (playerOnePlay == Play.Scissors && playerTwoPlay == Play.Rock)
        {
            score += 6;
        }
        else if (playerOnePlay == playerTwoPlay)
        {
            score += 3;
        }
        
        return score;
    }
        

   
    



    string[] GetFileContents()
    {
        string[] input = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/input.txt")
            .Split(new string[] { "\n" }, System.StringSplitOptions.None);
        return input;
    }
}