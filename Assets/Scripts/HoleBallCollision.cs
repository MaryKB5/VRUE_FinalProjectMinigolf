using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBallCollision : MonoBehaviour
{
    public GameObject ballPrefab;

    public GameObject startPosition;

    public ScoreManager scoreManager;

    private bool firstBallInHole = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {

            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.velocity = Vector3.zero;
                ballRb.isKinematic = true;
                Vector3 holePosition = transform.position;
                other.transform.position = new Vector3(holePosition.x, holePosition.y - 0.2f, holePosition.z);

                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource != null && !audioSource.isPlaying)
                {
                    Debug.Log("audio plays");
                    audioSource.Play();
                }

                if (startPosition != null)
                {
                    
                    Instantiate(ballPrefab, startPosition.transform.position, Quaternion.identity);
                }

                if (firstBallInHole)
                {
                    scoreManager.SaveAttemptsToListPlayerTwo();
                    scoreManager.NextHole();
                    scoreManager.ResetAttemptsPlayerTwo();
                    firstBallInHole = false;
                }
                else
                {
                    firstBallInHole = true;
                    scoreManager.SaveAttemptsToListPlayerOne();
                    scoreManager.ResetAttemptsPlayerOne();
                }
            }
        }
    }
}