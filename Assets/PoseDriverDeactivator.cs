using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PoseDriverDeactivator : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if(!photonView.IsMine) {
            Debug.Log("Destroying Camera + TrackedPoseDriver + AudioListener for other playar instance " + transform.name);
            Destroy(GetComponent<Camera>());
            Destroy(GetComponent<TrackedPoseDriver>());
            Destroy(GetComponent<AudioListener>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
