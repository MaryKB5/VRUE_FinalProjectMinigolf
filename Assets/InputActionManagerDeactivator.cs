using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class InputActionManagerDeactivator : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine) {
            Debug.Log("Destroy InputActionManager from other Player");
            InputActionManager controller = GetComponent<InputActionManager>();
            Destroy(controller);
        }
    }
}
