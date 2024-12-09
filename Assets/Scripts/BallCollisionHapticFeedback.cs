using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallCollisionHapticFeedback : MonoBehaviour
{
    public XRBaseController leftController;
    public XRBaseController rightController;

    public float hapticIntensity = 0.01f;
    public float hapticDuration = 0.01f;

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
        }
    }
}
