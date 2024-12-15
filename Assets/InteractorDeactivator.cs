using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class InteractorDeactivator : MonoBehaviourPun
{
    public GameObject pokeInteractor;
    public GameObject directInteractor;
    public GameObject rayInteractor;
    public GameObject teleportInteractor;


    // Start is called before the first frame update
    void Start()
    {

        if (!photonView.IsMine) {
            XRController controller = GetComponent<XRController>();
            Destroy(controller);
            Destroy(GetComponent<ActionBasedControllerManager>());


            XRInteractionGroup xRInteractionGroup = GetComponent<XRInteractionGroup>();
            Destroy(xRInteractionGroup);

            GameObject.Destroy(pokeInteractor);
            GameObject.Destroy(directInteractor);
            GameObject.Destroy(rayInteractor);
            GameObject.Destroy(teleportInteractor);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
