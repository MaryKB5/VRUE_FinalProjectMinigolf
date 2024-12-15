using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LocomotionSystemDeactivator : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine) {
            Debug.Log("Destroying Locomotion system for other player " + transform.name);
            Destroy(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
