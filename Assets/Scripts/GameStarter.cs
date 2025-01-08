
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviourPunCallbacks
{
    public GameObject originalXRInteractionSetup;

    public GameObject canvas;

    public GameObject lobbyPlane;

    public override void OnJoinedRoom() {
        if (PhotonNetwork.IsMasterClient) {
            transform.Find("Text").gameObject.GetComponent<Text>().text = "Start";            
        } else {
            transform.Find("Text").gameObject.GetComponent<Text>().text = "Wait for master";            
        }
    }

    public void OnGameStart()
    {
        Debug.Log("OnGameStart");
        if(PhotonNetwork.IsMasterClient) {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            PhotonNetwork.AutomaticallySyncScene = true;
            
            photonView.RPC("loadGame", RpcTarget.All);
        }
    }

    [PunRPC]
    private void loadGame() {
        Debug.Log("loadGame");
        PhotonNetwork.LoadLevel("Game");     
    }
}
