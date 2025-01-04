using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ReturnToLobby : MonoBehaviourPun
{
    public void BackToLobby()
    {
        Debug.Log("Returning to lobby");
        PhotonNetwork.LoadLevel("Lobby");
    }
}
