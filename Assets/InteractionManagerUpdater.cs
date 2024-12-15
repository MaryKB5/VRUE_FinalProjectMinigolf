using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionManagerUpdater : MonoBehaviour
{
    private TeleportationAnchor teleportationAnchor;
    private TeleportationArea teleportationArea;

    // Start is called before the first frame update
    void Start()
    {
        teleportationAnchor = GetComponent<TeleportationAnchor>();      
        teleportationArea = GetComponent<TeleportationArea>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (teleportationAnchor != null && teleportationAnchor.interactionManager == null) {    
            Debug.Log("TeleportationAnchor interactionmanager is null");
            XRInteractionManager xRInteractionManager = GameObject.FindAnyObjectByType<XRInteractionManager>();
            Debug.Log("Updating TeleportationAnchor.interactionManager to xrInteractionManager: " + xRInteractionManager);
            teleportationAnchor.interactionManager = xRInteractionManager;
        }

        if (teleportationArea != null && teleportationArea.interactionManager == null) {    
            Debug.Log("TeleportationArea interactionmanager is null");
            XRInteractionManager xRInteractionManager = GameObject.FindAnyObjectByType<XRInteractionManager>();
            Debug.Log("Updating TeleportationArea.interactionManager to xrInteractionManager: " + xRInteractionManager);
            teleportationArea.interactionManager = xRInteractionManager;
        }

    }
}
