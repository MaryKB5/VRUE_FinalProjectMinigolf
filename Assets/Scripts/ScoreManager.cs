using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int attemptsPlayerOne = 0;

    private int attemptsPlayerTwo = 0;

    public List<int> attemptsPlayerOneList = new List<int>(new int[4]); 
    public List<int> attemptsPlayerTwoList = new List<int>(new int[4]);

    private int currentHole = 0;

    public void IncreaseAttemptsPlayerOne()
    {
        attemptsPlayerOne++;
        Debug.Log("AttemptsPlayerOne" + attemptsPlayerOne);
    }

    public void IncreaseAttemptsPlayerTwo()
    {
        attemptsPlayerTwo++;
        Debug.Log("AttemptsPlayerTwo" + attemptsPlayerTwo);
    }

    public void SaveAttemptsToListPlayerOne()
    {
        attemptsPlayerOneList[currentHole] = attemptsPlayerOne;
        Debug.Log("Final Attempts Player 1:");
        for (int i = 0; i < attemptsPlayerOneList.Count; i++)
        {
            Debug.Log("Hole " + i + ": " + attemptsPlayerOneList[i]);
        }
    }

    public void SaveAttemptsToListPlayerTwo()
    {
        attemptsPlayerTwoList[currentHole] = attemptsPlayerTwo;
        Debug.Log("attempts player 2: " + attemptsPlayerTwoList);
    }

    public void NextHole()
    {
        currentHole++;
        Debug.Log("currentHole: " + currentHole);
    }

    public void ResetAttemptsPlayerOne()
    {
        attemptsPlayerOne = 0;
    }

    public void ResetAttemptsPlayerTwo()
    {
        attemptsPlayerTwo = 0;
    }
}
