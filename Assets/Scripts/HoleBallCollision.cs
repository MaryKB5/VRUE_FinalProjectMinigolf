using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class HoleBallCollision : MonoBehaviourPun
{
    
    public GameObject startPosition;

    private ScoreManager scoreManager;



    private bool firstBallInHole = true;

    void Start() {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            scoreManager = GameObject.FindAnyObjectByType<ScoreManager>();
            Debug.Log("ScoreManager: " + scoreManager);

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
                    if (PhotonNetwork.IsMasterClient) {
                        PhotonNetwork.Instantiate("Prefabs/Golf Ball", startPosition.transform.position, Quaternion.identity);
                    }
                }

                if (firstBallInHole)
                {
                    scoreManager.SaveAttemptsToListPlayerOne();
                    scoreManager.ResetAttemptsPlayerOne();
                    firstBallInHole = false;
                }
                else
                {
                    scoreManager.SaveAttemptsToListPlayerTwo();
                    scoreManager.NextHole();
                    scoreManager.ResetAttemptsPlayerTwo();
                    
                    firstBallInHole = true;
                }
            }
        }
    }
}