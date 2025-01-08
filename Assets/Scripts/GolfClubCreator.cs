using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GolfClubCreator : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient) {
            Debug.Log("Creating golf club");
            Vector3 newPosition = transform.position + new Vector3(-7.5f, 1.0f, 0.8f);
            GameObject club1 = PhotonNetwork.InstantiateRoomObject("Prefabs/Golf Club Player 1", newPosition, Quaternion.Euler(0, 90, 0));
            club1.SetActive(true);

            Vector3 newPosition2 = transform.position + new Vector3(-7.5f, 1.0f, -0.8f);
            GameObject club2 = PhotonNetwork.InstantiateRoomObject("Prefabs/Golf Club", newPosition2, Quaternion.Euler(0, 90, 0));
            club2.SetActive(true);

        } else {
            Debug.Log("Didn't create golf club");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
