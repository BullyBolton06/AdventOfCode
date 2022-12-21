using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayFour : MonoBehaviour
{
    // Start is called before the first frame update
    int totalCount = 0;
    void Start()
    {
        foreach (var PairOfRanges in GetFileContents())
        {
            string[] Ranges = PairOfRanges.Split(',');
            //in Ranges[0] is the first range, in Ranges[1] is the second range in the format "1-3". If the ranges overlap at all, the total count is increased by 1.
            string[] Range1 = Ranges[0].Split('-');
            string[] Range2 = Ranges[1].Split('-');
            int Range1Min = int.Parse(Range1[0]);
            int Range1Max = int.Parse(Range1[1]);
            int Range2Min = int.Parse(Range2[0]);
            int Range2Max = int.Parse(Range2[1]);
            if (Range1Min <= Range2Min && Range1Max >= Range2Min)
            {
                totalCount++;
            }
            else if (Range2Min <= Range1Min && Range2Max >= Range1Min)
            {
                totalCount++;
            }
            
        }
        
        Debug.Log(totalCount);
    }

    string[] GetFileContents()
    {
        string[] input = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/input4.txt")
            .Split(new string[] { "\n" }, System.StringSplitOptions.None);
        return input;
    }

}
