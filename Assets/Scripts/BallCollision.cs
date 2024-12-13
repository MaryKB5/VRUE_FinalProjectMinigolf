using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallCollision : MonoBehaviour
{
    public XRBaseController leftController;
    public XRBaseController rightController;

    public float hapticIntensity = 0.01f;
    public float hapticDuration = 0.01f;

    public ScoreManager scoreManager;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            if (leftController != null)
            {
                leftController.SendHapticImpulse(hapticIntensity, hapticDuration);
            }

            if (rightController != null)
            {
                rightController.SendHapticImpulse(hapticIntensity, hapticDuration);
            }

            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }


            if (CompareTag("Player1GolfClub"))
            {
                scoreManager.IncreaseAttemptsPlayerOne();
            }
            else if (CompareTag("Player2GolfClub"))
            {
                scoreManager.IncreaseAttemptsPlayerTwo();
            }


        }
    }
}
