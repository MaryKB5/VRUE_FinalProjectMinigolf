using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class EventSystemDeactivator : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
         if (!photonView.IsMine) {
            Debug.Log("Destroy EventSystem from other Player");
            EventSystem eventSystem = GetComponent<EventSystem>();
            Destroy(eventSystem);

            Debug.Log("Destroy XRUIInputModule from other Player");
            XRUIInputModule xRUIInputModule = GetComponent<XRUIInputModule>();
            Destroy(xRUIInputModule);
        }
    }
}
