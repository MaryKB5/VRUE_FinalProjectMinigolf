using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameLogicStarter : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.Instantiate("Prefabs/ScoreManager", Vector3.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
