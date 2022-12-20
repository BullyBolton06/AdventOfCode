using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DayTwo : MonoBehaviour
{
    int totalScore = 0;

    private void Start()
    {
        var games = GetFileContents();
        foreach (var game in games)
        {
            var gameData = game.Split(' ');
        }
    }


    void CalculateScore()
    {
        
        
       
        
        
        
        
        
             
    }

    string[] GetFileContents()
    {
        string[] input = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/input.txt")
            .Split(new string[] { "\n" }, System.StringSplitOptions.None);
        return input;
    }
}