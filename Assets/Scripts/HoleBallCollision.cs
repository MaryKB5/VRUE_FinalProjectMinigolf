using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBallCollision : MonoBehaviour
{
    public GameObject ballPrefab;

    public GameObject startPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball in hole");

            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            if (ballRb != null)
            {

                ballRb.velocity = Vector3.zero;
                ballRb.isKinematic = true;

                Vector3 holePosition = transform.position;
                other.transform.position = new Vector3(holePosition.x, holePosition.y - 0.2f, holePosition.z);

                if (startPosition != null)
                {
                    
                    Instantiate(ballPrefab, startPosition.transform.position, Quaternion.identity);
                }
            }
        }
    }
}