using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BallCreator : MonoBehaviourPun
{
    public GameObject startPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.Instantiate("Prefabs/Golf Ball", startPosition.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
