using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameEnvironment = GameObject.Find("Game Environment");
        if (gameEnvironment != null) {
            Debug.Log("Deactivating Game Environment during Lobby");
            gameEnvironment.SetActive(false);
        } else {
            Debug.LogWarning("No Game Environment Found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
