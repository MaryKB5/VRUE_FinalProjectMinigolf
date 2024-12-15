using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class OriginDeactivator : MonoBehaviourPun
{
    // Start is called before the first frame update
    
    void Start()
    {
        if(!photonView.IsMine) {
            Debug.Log("Removing XR Origin component for other player");
            XROrigin xROrigin = GetComponent<XROrigin>();
            Destroy(xROrigin);

            //GameObject mainCamera = transform.Find("Main Camera").gameObject;
            //Debug.Log("MainCamera: " + mainCamera);
            //Destroy(mainCamera.GetComponent<Camera>());
            //Destroy(mainCamera.GetComponent<AudioListener>());
            //Destroy(mainCamera.GetComponent<TrackedPoseDriver>());

                   
            Transform leftController = transform.Find("Left Controller");
            Debug.Log("LeftController " + leftController);
            destroyInteractors(leftController);

            Transform rightController = transform.Find("Right Controller");
            Debug.Log("RightController " + rightController);

            destroyInteractors(rightController);
        }
    }

    private void destroyInteractors(Transform controller) {
        Transform pokeInteractor = controller.Find("Poke Interactor");
        Debug.Log(pokeInteractor);
        GameObject.Destroy(pokeInteractor.gameObject);            
        GameObject.Destroy(controller.Find("Direct Interactor").gameObject);            
        GameObject.Destroy(controller.Find("Ray Interactor").gameObject);         
        GameObject.Destroy(controller.Find("Teleport Interactor").gameObject);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
