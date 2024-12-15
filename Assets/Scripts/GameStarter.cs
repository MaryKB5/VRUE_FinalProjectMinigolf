using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public GameObject originalXRInteractionSetup;

    public GameObject canvas;

    // Start is called before the first frame update
    public void OnGameStart()
    {
        GameObject gameEnvironment = GameObject.Find("Game Environment");
        

        //SceneManager.UnloadSceneAsync("Lobby");


        if (gameEnvironment != null) {
            Debug.Log("Activating Game Environment");
            gameEnvironment.SetActive(true);
        } else {
            Debug.LogWarning("Instantiating Game Environment");
            PhotonNetwork.Instantiate("Game Environment", Vector3.zero, Quaternion.identity);
            gameEnvironment =  GameObject.Find("Game Environment");
            
            
            
            
        }

        GameObject.Destroy(originalXRInteractionSetup);
        Debug.Log(canvas);
        GameObject.Destroy(canvas);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
