using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class SpawnEmoji : MonoBehaviourPun
{
    public GameObject emojiPrefab; 
    public GameObject rightController; 
    public Vector3 emojiOffset = new Vector3(0, 0.2f, 0); 

    private GameObject spawnedEmoji; 
    private float emojiSpawnTime; 

    void Update()
    {
       
        if (IsRightTriggerPressed())
        {
            if (spawnedEmoji == null)
            {
                Spawn();

                photonView.RPC("SyncEmojiSpawn", RpcTarget.Others, rightController.transform.position + emojiOffset);
            }
        }

        if (spawnedEmoji != null && Time.time - emojiSpawnTime > 2f)
        {
            Destroy(spawnedEmoji);
            photonView.RPC("SyncEmojiDespawn", RpcTarget.Others);
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
        spawnedEmoji = Instantiate(emojiPrefab, rightController.transform.position + emojiOffset, emojiRotation);

        spawnedEmoji.transform.SetParent(rightController.transform);

        emojiSpawnTime = Time.time;
    }

    [PunRPC]
    private void SyncEmojiSpawn(Vector3 spawnPosition)
    {
        if (spawnedEmoji == null)
        {
            Quaternion emojiRotation = rightController.transform.rotation * Quaternion.Euler(-60, 0, 0);
            spawnedEmoji = Instantiate(emojiPrefab, spawnPosition, emojiRotation);
            spawnedEmoji.transform.SetParent(rightController.transform);
            emojiSpawnTime = Time.time;
        }
    }

    [PunRPC]
    private void SyncEmojiDespawn()
    {
        if (spawnedEmoji != null)
        {
            Destroy(spawnedEmoji);
        }
    }
}
