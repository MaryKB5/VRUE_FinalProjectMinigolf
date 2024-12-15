using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinGameLobbyCleaner : MonoBehaviour
{
    public GameObject lobby;
    public void OnStart()
    {
        GameObject.Destroy(lobby);
    }
}
