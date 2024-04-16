using UnityEngine;

public class easeInBounce : MonoBehaviour
{
    public float duration1 = 1f; // Total duration of the animation
    public Vector3 startPosition1 = new Vector3(0, 0, 0); // Start position of the animation
    public Vector3 endPosition1 = new Vector3(0, 5, 0); // End position of the animation

    private float elapsedTime1 = 0f;

    void Update()
    {
        if (elapsedTime1 < duration1)
        {
            // Calculate the completion ratio from 0 to 1
            float t = elapsedTime1 / duration1;

            // Apply easeInBounce function to calculate eased ratio
            t = EaseInBounce1(t);

            // Interpolate position based on eased ratio
            transform.position = Vector3.Lerp(startPosition1, endPosition1, t);

            // Increment elapsed time
            elapsedTime1 += Time.deltaTime;
        }
    }

    // Custom easeInBounce function
    float EaseInBounce1(float t)
    {
        // Use 1 - EaseOutBounce(1 - t) to achieve easeInBounce effect
        return 1f - EaseOutBounce1(1f - t);
    }

    // Helper function for easeOutBounce
    float EaseOutBounce1(float t)
    {
        if (t < 1 / 2.75f)
        {
            return 7.5625f * t * t;
        }
        else if (t < 2 / 2.75f)
        {
            t -= 1.5f / 2.75f;
            return 7.5625f * t * t + 0.75f;
        }
        else if (t < 2.5f / 2.75f)
        {
            t -= 2.25f / 2.75f;
            return 7.5625f * t * t + 0.9375f;
        }
        else
        {
            t -= 2.625f / 2.75f;
            return 7.5625f * t * t + 0.984375f;
        }
    }
}
