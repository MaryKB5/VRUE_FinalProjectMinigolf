using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    // Start is called before the first frame update

    private float emojiSpawnTime; 
    private bool destroyed = false;
    void Start()
    {
        emojiSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!destroyed && Time.time - emojiSpawnTime > 2f) {
            Debug.Log("Destroying emoji");
            destroyed = true;
            Destroy(gameObject);
        }
    }
}
