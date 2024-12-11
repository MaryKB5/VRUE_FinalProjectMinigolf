using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnEmoji : MonoBehaviour
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
            }
        }

        if (spawnedEmoji != null && Time.time - emojiSpawnTime > 2f)
        {
            Destroy(spawnedEmoji);
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
        spawnedEmoji = Instantiate(emojiPrefab, rightController.transform.position + emojiOffset, emojiPrefab.transform.rotation);

        spawnedEmoji.transform.SetParent(rightController.transform);

        emojiSpawnTime = Time.time;
    }
}
