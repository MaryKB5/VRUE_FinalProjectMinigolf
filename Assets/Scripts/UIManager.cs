using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public List<TextMeshProUGUI> player1Texts;
    public List<TextMeshProUGUI> player2Texts; 

    public ScoreManager scoreManager;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < player1Texts.Count; i++)
        {
            if (i < scoreManager.attemptsPlayerOneList.Count)
            {
                Debug.Log("upadting UI");
                player1Texts[i].text = scoreManager.attemptsPlayerOneList[i].ToString();
            }
            
        }

        for (int i = 0; i < player2Texts.Count; i++)
        {
            if (i < scoreManager.attemptsPlayerTwoList.Count)
            {
                player2Texts[i].text = "hallo";
                player2Texts[i].text = scoreManager.attemptsPlayerTwoList[i].ToString();
            }
            
        }
    }
}
