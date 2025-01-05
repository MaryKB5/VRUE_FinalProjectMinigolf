using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.XR;

public class NetworkPlayer : MonoBehaviourPun
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    public Vector3 emojiOffset = new Vector3(0, 0.2f, 0); 

    private GameObject spawnedEmoji; 
    private float emojiSpawnTime; 


    private GameObject xrOrigin;

    // Start is called before the first frame update
    void Start() {
        xrOrigin = GameObject.Find("XR Origin (XR Rig)");
        Debug.Log("Found XR setup: " + xrOrigin);

        headRig = xrOrigin.transform.Find("Camera Offset/Main Camera");
        Debug.Log("Found headRig: " + headRig);
        leftHandRig = xrOrigin.transform.Find("Camera Offset/Left Controller");
        Debug.Log("Found leftHandRig: " + leftHandRig);
        rightHandRig = xrOrigin.transform.Find("Camera Offset/Right Controller");
        Debug.Log("Found rightHandRig: " + rightHandRig);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = xrOrigin.transform.position; 

       /* if (photonView.IsMine) {
            photonView.RPC("SyncPosition", RpcTarget.Others, transform.position, transform.rotation);
        }*/

        // Debug.Log("xrOrigin position " + position);

        if(photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

            //Debug.Log("Mapping position for player no. " + photonView.Owner.GetPlayerNumber());

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);   
        }

        if (spawnedEmoji != null && Time.time - emojiSpawnTime > 2f)
        {
            Destroy(spawnedEmoji);
            photonView.RPC("SyncEmojiDespawn", RpcTarget.Others);
        }
    }

    /*[PunRPC]
    private void SyncPosition(Vector3 position, Quaternion rotation) {
        if (!photonView.IsMine) return;
        
        Debug.Log("Syncing position for player no. " + photonView.Owner.GetPlayerNumber());
        gameObject.transform.position = position;
        gameObject.transform.rotation = rotation;
    }*/

    void MapPosition(Transform target,Transform rigTransform)
    {
       // InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
       // InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
        /*if (node == XRNode.Head) {
            Debug.Log("head devicePosition " + position);
        }*/
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

  
    [PunRPC]
    private void SyncEmojiSpawn(Vector3 spawnPosition)
    {
        if (spawnedEmoji == null)
        {
            Quaternion emojiRotation = rightHand.transform.rotation * Quaternion.Euler(-60, 0, 0);

            Vector3 spawnPositionHand = rightHand.transform.position + emojiOffset;

            spawnedEmoji = PhotonNetwork.Instantiate("star_eyes_smile_face Variant", spawnPositionHand, emojiRotation);
            spawnedEmoji.transform.SetParent(rightHand.transform);
            emojiSpawnTime = Time.time;
        }
    }

    [PunRPC]
    private void SyncEmojiDespawn()
    {
        if (spawnedEmoji != null)
        {
            PhotonNetwork.Destroy(spawnedEmoji);
        }
    }
}
