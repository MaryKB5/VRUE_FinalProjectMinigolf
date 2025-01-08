using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Unity.Mathematics;

public class SpawnEmoji : MonoBehaviourPun
{
    private GameObject rightController; 
    public Vector3 emojiOffset = new Vector3(0, 0.2f, 0); 

    private GameObject spawnedEmoji; 
    private float emojiSpawnTime; 


    void Start() {
        if (photonView.IsMine) {
            GameObject xrOrigin = GameObject.Find("XR Origin (XR Rig)");
            Debug.Log("SpawnEmoji: Found XR setup: " + xrOrigin);

            rightController = xrOrigin.transform.Find("Camera Offset/Right Controller").gameObject;
            Debug.Log("SpawnEmoji: Found rightController: " + rightController);
        }
    }
    void Update()
    {
        if (photonView.IsMine) {
            if (IsRightTriggerPressed())
            {
                if (spawnedEmoji == null)
                {
                    Spawn();

                    photonView.RPC("SyncEmojiSpawn", RpcTarget.Others);
                }
            }

            if (spawnedEmoji != null && Time.time - emojiSpawnTime > 2f)
            {
                spawnedEmoji = null;
            }
        }
    }

    private bool IsRightTriggerPressed()
    {
        InputDevice rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (rightController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            return triggerValue > 0.1f;
        }

        return false;
    }

    private void Spawn()
    {
        Quaternion emojiRotation = rightController.transform.rotation * Quaternion.Euler(-60, 0, 0);
        spawnedEmoji = PhotonNetwork.Instantiate("Prefabs/star_eyes_smile_face Variant", rightController.transform.position + emojiOffset, emojiRotation);

        spawnedEmoji.transform.SetParent(rightController.transform);

        emojiSpawnTime = Time.time;
    }

    [PunRPC]
    private void SyncEmojiSpawn(Vector3 spawnPosition)
    {
        if (spawnedEmoji == null)
        {   
            Vector3 spawnPositionRightController = rightController.transform.position + emojiOffset;
            Quaternion emojiRotation = rightController.transform.rotation * Quaternion.Euler(-60, 0, 0);
            spawnedEmoji = PhotonNetwork.Instantiate("Prefabs/star_eyes_smile_face Variant", spawnPositionRightController, emojiRotation);
            spawnedEmoji.transform.SetParent(rightController.transform);
            emojiSpawnTime = Time.time;
        }
    }
}
