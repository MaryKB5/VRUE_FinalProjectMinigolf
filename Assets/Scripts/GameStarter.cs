
using Photon.Pun;
using UnityEngine;

public class GameStarter : MonoBehaviourPun
{
    public GameObject originalXRInteractionSetup;

    public GameObject canvas;

    public GameObject lobbyPlane;

    public void OnGameStart()
    {
        Debug.Log("OnGameStart");
        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        PhotonNetwork.AutomaticallySyncScene = true;
           
        photonView.RPC("loadGame", RpcTarget.All);
    }

    [PunRPC]
    private void loadGame() {
        Debug.Log("loadGame");
        PhotonNetwork.LoadLevel("Game");     
    }
}
