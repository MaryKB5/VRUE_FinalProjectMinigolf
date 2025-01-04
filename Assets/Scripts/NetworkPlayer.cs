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

    public Vector3 emojiOffset = new Vector3(0, 0.2f, 0); 

    private GameObject spawnedEmoji; 
    private float emojiSpawnTime; 


    private GameObject xrSetup;

    // Start is called before the first frame update
    void Start() {
        xrSetup = GameObject.Find("XR Interaction Setup Variant");
        Debug.Log("Found XR setup: " + xrSetup);
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

//            Debug.Log("Mapping position for player no. " + photonView.Owner.GetPlayerNumber());
            gameObject.transform.position = xrSetup.transform.position;
            gameObject.transform.rotation = xrSetup.transform.rotation;

            MapPosition(head, XRNode.Head);
            MapPosition(leftHand, XRNode.LeftHand);
            MapPosition(rightHand, XRNode.RightHand);
        }

        if (spawnedEmoji != null && Time.time - emojiSpawnTime > 2f)
        {
            Destroy(spawnedEmoji);
            photonView.RPC("SyncEmojiDespawn", RpcTarget.Others);
        }
    }

    void MapPosition(Transform target,XRNode node)
    {
        
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = position;
        target.rotation = rotation;
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
