using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ScoreManager : MonoBehaviourPun
{
    private UIManager uiManager;
    private int attemptsPlayerOne = 0;
    private int attemptsPlayerTwo = 0;

    public List<int> attemptsPlayerOneList = new List<int> { 0, 0, 0, 0 };
    public List<int> attemptsPlayerTwoList = new List<int> { 0, 0, 0, 0 };

    private TextMeshProUGUI playerOneResultText; 
    private TextMeshProUGUI playerTwoResultText;

    private GameObject resultsCanvas;

    private int currentHole = 0;


    void Start()
    {
        //resultsCanvas.SetActive(false);
        GameObject.Find("UIManager").TryGetComponent(out uiManager);
        uiManager.scoreManager = this;
        resultsCanvas = GameObject.Find("Results");
        playerOneResultText = GameObject.Find("Player 1 Results").GetComponent<TextMeshProUGUI>();
        playerTwoResultText = GameObject.Find("Player 2 Results").GetComponent<TextMeshProUGUI>();
        Debug.Log("UIManager: " + uiManager);
        Debug.Log("PlayerOneResultText: " + playerOneResultText);
        Debug.Log("PlayerTwoResultText: " + playerTwoResultText);

    }
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
        uiManager.UpdateUI();
    }

    public void SaveAttemptsToListPlayerTwo()
    {
        attemptsPlayerTwoList[currentHole] = attemptsPlayerTwo;
        Debug.Log("attempts player 2: " + attemptsPlayerTwoList);

        uiManager.UpdateUI();
    }

    public void NextHole()
    {
        currentHole++;
        Debug.Log("currentHole: " + currentHole);

        //if(currentHole == 4)
        //{
            DisplayResults();
        //}
    }

    public void ResetAttemptsPlayerOne()
    {
        attemptsPlayerOne = 0;
    }

    public void ResetAttemptsPlayerTwo()
    {
        attemptsPlayerTwo = 0;
    }

    public int GetResultPlayerOne()
    {
        int resultOne = 0;
        foreach (int attempts in attemptsPlayerOneList)
        {
            resultOne += attempts;
        }
        return resultOne;
    }

    public int GetResultPlayerTwo()
    {
        int resultTwo = 0;
        foreach (int attempts in attemptsPlayerTwoList)
        {
            resultTwo += attempts;
        }
        return resultTwo;
    }

    private void DisplayResults()
    {
        int playerOneScore = GetResultPlayerOne();
        int playerTwoScore = GetResultPlayerTwo();

        playerOneResultText.text = playerOneScore.ToString();
        playerTwoResultText.text = playerTwoScore.ToString();

        resultsCanvas.SetActive(true);
    }

}
