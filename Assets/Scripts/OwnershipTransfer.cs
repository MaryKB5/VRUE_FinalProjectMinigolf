using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OwnershipTransfer : MonoBehaviourPun
{
    
   // private GameObject xrOrigin;

    // Start is called before the first frame update
    void Start()
    {
        /*xrOrigin = GameObject.Find("XR Origin (XR Rig)");
        Debug.Log("Found XR setup: " + xrOrigin);*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSelect(SelectEnterEventArgs selectEnterEventArgs)
    {
        // Implement the logic for when the object is selected
        Debug.Log("Object selected: " + selectEnterEventArgs.interactableObject);
        GameObject interactor = selectEnterEventArgs.interactorObject.transform.gameObject;
        Debug.Log("Interactor: " + interactor);
        
        photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        /*PhotonView[] photonViews = xrOrigin.GetPhotonViewsInChildren();
        foreach (PhotonView photonView in photonViews)
        {
            Debug.Log("PhotonView: " + photonView);
            
        }*/
        
    }
}
