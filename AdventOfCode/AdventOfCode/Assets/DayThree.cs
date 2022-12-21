using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayThree : MonoBehaviour
{
    int totalSumOfPriorities = 0;
    string[] GetFileContents()
    {
        string[] input = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/input3.txt")
            .Split(new string[] { "\n" }, System.StringSplitOptions.None);
        return input;
    }

    private void Start()
    {
        //in each string in rucksacks, find the character that appears in both the first half and the second half of the string
        string[] rucksacks = GetFileContents();
        
        //find the common character in each group of 3 strings in the array
        for (int i = 0; i < rucksacks.Length; i += 3)
        {
            string first = rucksacks[i];
            string second = rucksacks[i + 1];
            string third = rucksacks[i + 2];
            foreach (var t in first)
            {
                if (second.Contains(t) && third.Contains(t))
                {
                    if (char.IsUpper(t))
                    {
                        //add 27 for 'A' to total sum of priorities, 28 for 'B', etc.
                        totalSumOfPriorities += (int)t - 38;
                    }
                    else
                    {
                        //add 1 for 'a' to total sum of priorities, 2 for 'b', etc.
                        totalSumOfPriorities += (int)t - 96;
                    }
                    break;
                }
            }
        }
        
        Debug.Log(totalSumOfPriorities);
    }
}
