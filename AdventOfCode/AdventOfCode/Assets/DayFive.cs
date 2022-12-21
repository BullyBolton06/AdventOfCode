using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DayFive : MonoBehaviour
{
    private List<List<char>> Stacks;
    private int indexOfStartOfCommands = 0;
    int indexOfStackIndexes = 0;
    private void Start()
    {
        Stacks = new List<List<char>>();
        var lines = GetFileContents();
        PutCrateInformationIntoLists(lines);
        ProcessCommands(lines);
    }

    private void ProcessCommands()
    {
        indexOfStartOfCommands = indexOfStackIndexes + 2;
        
    }


    void PutCrateInformationIntoLists(string[] lines)
    {
        indexOfStackIndexes = 0;
        for (int i = 0;  i< lines.Length; i++)
        {
            //find first line that contains an integer
            if (lines[i].Any(char.IsDigit))
            {
                indexOfStackIndexes = i;
                //find last digit in line i.e the number of stacks
                int index = lines[i].Length - 1;
                while (!char.IsDigit(lines[i][index]))
                {
                    index--;
                }
                //create a new list of stacks
                Debug.Log(lines[i][index]);
                for (int j = 0; j < char.GetNumericValue(lines[i][index]); j++)
                {
                    Stacks.Add(new List<char>());
                }

                break;
            }
        }
        
        //put the crates into the stacks. each crate is a substring which looks like this "[C]". There is a space between each crate in the string.
        //Some stacks are higher than others, so we need to account for there being empty "   " spaces in the string.
        for (int i = 0; i < indexOfStackIndexes; i++)
        {
            for (int j = 1; j < lines[i].Length; j+=4)
            {
              if(lines[i][j] != ' ')
              {
                Stacks[(j-1)/4].Insert(0,lines[i][j]);
              }   
            }
        }
        
        //print out the stacks
        for (int i = 0; i < Stacks.Count; i++)
        {
            string stack = "";
            for (int j = 0; j < Stacks[i].Count; j++)
            {
                stack += Stacks[i][j];
            }
            
            Debug.Log(stack);
        }

    }

    
        

    string[] GetFileContents()
    {
        string[] input = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/input5.txt")
            .Split(new string[] { "\n" }, System.StringSplitOptions.None);
        return input;
    }
}