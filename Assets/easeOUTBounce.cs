using UnityEngine;

public class BounceAnimation : MonoBehaviour
{
    public float duration = 5f; // Total duration of the animation
    public Vector3 startPosition = new Vector3(0, 0, 0); // Start position of the animation
    public Vector3 endPosition = new Vector3(0, 5, 0); // End position of the animation

    private float elapsedTime = 0f;

    void Update()
    {
        if (elapsedTime < duration)
        {
            // Calculate the completion ratio from 0 to 1
            float t = elapsedTime / duration;

            // Apply easeInBounce function to calculate eased ratio
            t = EaseInBounce(t);

            // Interpolate position based on eased ratio
            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            // Increment elapsed time
            elapsedTime += Time.deltaTime;
        }
    }

    // Custom easeInBounce function
    float EaseInBounce(float t)
    {
        // Calculate the easing using Mathf
        return 1f - EaseOutBounce(1f - t);
    }

    // Helper easeOutBounce function
    float EaseOutBounce(float t)
    {
        if (t < 1 / 2.75)
        {
            return 7.5625f * t * t;
        }
        else if (t < 2 / 2.75)
        {
            t -= 1.5f / 2.75f;
            return 7.5625f * t * t + 0.75f;
        }
        else if (t < 2.5 / 2.75)
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
