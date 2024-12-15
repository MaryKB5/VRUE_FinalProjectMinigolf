using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionManagerUpdater : MonoBehaviour
{
    private TeleportationAnchor teleportationAnchor;
    private TeleportationArea teleportationArea;

    private XRGrabInteractable xRGrabInteractable;

    // Start is called before the first frame update
    void Start()
    {
        teleportationAnchor = GetComponent<TeleportationAnchor>();      
        teleportationArea = GetComponent<TeleportationArea>();
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
        private float nextActionTime = 0.0f;
    private float period = 1.0f;



    void Update() {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
        
            if (teleportationAnchor != null ) { 
                Debug.Log("TeleportationAnchor interactionmanager is null");
                XRInteractionManager xRInteractionManager = GameObject.FindAnyObjectByType<XRInteractionManager>();
                Debug.Log("Updating TeleportationAnchor.interactionManager to xrInteractionManager: " + xRInteractionManager);
                teleportationAnchor.interactionManager = xRInteractionManager;
            }

            if (teleportationArea != null ) { 
                Debug.Log("TeleportationArea interactionmanager is null");
                XRInteractionManager xRInteractionManager = GameObject.FindAnyObjectByType<XRInteractionManager>();
                Debug.Log("Updating TeleportationArea.interactionManager to xrInteractionManager: " + xRInteractionManager);
                teleportationArea.interactionManager = xRInteractionManager;
            }


            if (xRGrabInteractable != null ) {    
                Debug.Log("xRGrabInteractable interactionmanager is null");
                XRInteractionManager xRInteractionManager = GameObject.FindAnyObjectByType<XRInteractionManager>();
                Debug.Log("Updating xRGrabInteractable.interactionManager to xrInteractionManager: " + xRInteractionManager);
                xRGrabInteractable.interactionManager = xRInteractionManager;
            }
        }

    }
}
