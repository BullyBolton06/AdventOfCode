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
        Scissors,
    }   
    
    public enum Result
    {
        Win,
        Lose,
        Draw,
    }
    
    Dictionary<string,Result> results = new Dictionary<string, Result>()
    {
        {"X", Result.Lose},
        {"Y", Result.Draw},
        {"Z", Result.Win}
    };
    Dictionary<string,Play> plays = new Dictionary<string, Play>()
    {
        {"A", Play.Rock},
        {"B", Play.Paper},
        {"C", Play.Scissors},
        
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
     
        var playerOnePlay = plays[game[0]];
        var result = results[game[1]];
        
        //work out what the player two has played is if playerOnePlay represents what player one played and result represents the result of the game
        Play? playerTwoPlay = null;
        
        switch (playerOnePlay)
        {
            case Play.Rock:
                switch (result)
                {
                    case Result.Win:
                        playerTwoPlay = Play.Paper;
                        break;
                    case Result.Lose:
                        playerTwoPlay = Play.Scissors;
                        break;
                    case Result.Draw:
                        playerTwoPlay = Play.Rock;
                        break;
                }
                break;
            case Play.Paper:
                switch (result)
                {
                    case Result.Win:
                        playerTwoPlay = Play.Scissors;
                        break;
                    case Result.Lose:
                        playerTwoPlay = Play.Rock;
                        break;
                    case Result.Draw:
                        playerTwoPlay = Play.Paper;
                        break;
                }
                break;
            case Play.Scissors:
                switch (result)
                {
                    case Result.Win:
                        playerTwoPlay = Play.Rock;
                        break;
                    case Result.Lose:
                        playerTwoPlay = Play.Paper;
                        break;
                    case Result.Draw:
                        playerTwoPlay = Play.Scissors;
                        break;
                }
                break;
        }
        
        
        if (result == Result.Win)
        {
            score += 6;
        }
        else if (result == Result.Draw)
        {
            score +=3 ;
        }

        if (playerTwoPlay== Play.Rock)
        {
            score += 1;
        }
        else if (playerTwoPlay == Play.Paper)
        {
            score += 2;
        }else if (playerTwoPlay == Play.Scissors)
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