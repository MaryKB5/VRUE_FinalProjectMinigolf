using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionManagerDeactivator : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine) {
            Debug.Log("Destroy XRInteraftionManager from other Player");
            XRInteractionManager controller = GetComponent<XRInteractionManager>();
            Destroy(controller);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
