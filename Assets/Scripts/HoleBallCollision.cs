using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBallCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball in hole");

            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                // Stop ball movement
                ballRb.velocity = Vector3.zero;
                ballRb.isKinematic = true;

                // Position ball slightly below the hole
                Vector3 holePosition = transform.position;
                other.transform.position = new Vector3(holePosition.x, holePosition.y - 0.2f, holePosition.z);
            }
            else
            {
                Debug.LogError("No Rigidbody found on the ball!");
            }
        }
    }
}
