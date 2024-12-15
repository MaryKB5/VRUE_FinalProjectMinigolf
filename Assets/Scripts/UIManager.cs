using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Photon.Pun;

public class UIManager : MonoBehaviourPun
{
    public List<TextMeshProUGUI> player1Texts;
    public List<TextMeshProUGUI> player2Texts; 

    public ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindAnyObjectByType<ScoreManager>();
        Debug.Log(scoreManager);
        UpdateUI();
    }

    private float nextActionTime = 0.0f;
    private float period = 0.2f;



    void Update() {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
        
            this.UpdateUI();
        }
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
