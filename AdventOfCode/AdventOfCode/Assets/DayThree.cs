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
        foreach (string rucksack in rucksacks)
        {
            string firstHalf = rucksack.Substring(0, rucksack.Length / 2);
            string secondHalf = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);
            foreach (char c in firstHalf)
            {
                if (secondHalf.Contains(c))
                {
                    if (char.IsUpper(c))
                    {
                        //add 27 for 'A' to total sum of priorities, 28 for 'B', etc.
                        totalSumOfPriorities += (int)c - 38;
                    }
                    else
                    {
                        //add 1 for 'a' to total sum of priorities, 2 for 'b', etc.
                        totalSumOfPriorities += (int)c - 96;
                    }
                    break;
                }
            }
        }
        
        Debug.Log(totalSumOfPriorities);
    }
}
