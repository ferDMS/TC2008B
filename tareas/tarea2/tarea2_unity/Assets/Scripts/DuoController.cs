using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DuoController : MonoBehaviour
{
    // For rotation
    public Vector3 deltaRotationAngles;
	public float rotationSpeed = 1f;

    // For scaling
    public float scalePercentageLimit;
    private bool isScalingUp = true;
    private float upScaleLimit;
    private float downScaleLimit;
    public float scalingPercentageSpeed = 1f;

    // For translation
    public float translateDistLimit;
    private bool isTranslatingRight = true;
    private float rightTranslateLimit;
    private float leftTranslateLimit;
    public float translateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize up and down scale limits
        upScaleLimit = transform.localScale.magnitude * (1 + scalePercentageLimit / 100);
        downScaleLimit = transform.localScale.magnitude * (1 - scalePercentageLimit / 100);

        print($"Scale percentage limit:\nup: {upScaleLimit}, down:{downScaleLimit}");

        // Initialize left and right position limits
        leftTranslateLimit = transform.position.x - translateDistLimit;
        rightTranslateLimit = transform.position.x + translateDistLimit;

        print($"Position x limit:\nleft: {leftTranslateLimit}, right:{rightTranslateLimit}");

        // Initial position (with respect to parents)
        double x = transform.position.x;
        double y = transform.position.y;
        double z = transform.position.z;

        print($"Initial position: ({x}, {y}, {z})");
    }

    // Update is called once per frame
    void Update()
    {
        Translate();
        Scale();
        Rotate();
    }

    void Translate()
    {
        Vector3 currentPosition = transform.localPosition;

        if ((isTranslatingRight && currentPosition.x > rightTranslateLimit) || (!isTranslatingRight && currentPosition.x < leftTranslateLimit))
        {
            isTranslatingRight = !isTranslatingRight;
        }

        Vector3 newPosition;
        if (isTranslatingRight)
        {
            newPosition = new Vector3(
                currentPosition.x + (translateSpeed * Time.deltaTime),
                currentPosition.y,
                currentPosition.z
            );
        }
        else
        {
            newPosition = new Vector3(
                currentPosition.x - (translateSpeed * Time.deltaTime),
                currentPosition.y,
                currentPosition.z
            );
        }

        transform.localPosition = newPosition;
    }

    void Scale()
    {
        Vector3 currentScale = transform.localScale;

        // If we reach upper scale limit, toggle scale direction. Same for lower scale limit
        if ((isScalingUp && currentScale.magnitude > upScaleLimit) || (!isScalingUp && currentScale.magnitude < downScaleLimit))
        {
            isScalingUp = !isScalingUp;
        }

        // Make scale change
        Vector3 newScale;
        if (isScalingUp)
        {
            newScale = currentScale * (1 + scalingPercentageSpeed * 0.1f / 100); // 0.1f to slow it down a bit
        } 
        else
        {
            newScale = currentScale * (1 - scalingPercentageSpeed * 0.1f / 100);
        }

        transform.localScale = newScale;
    }

    void Rotate()
    {
        Quaternion currentRotation = transform.rotation;

        Quaternion newRotation = currentRotation * Quaternion.Euler(deltaRotationAngles);

        float t = rotationSpeed * 40 * Time.deltaTime; // 40 to speed it up a bit
        
        Quaternion interpolatedRotation = Quaternion.Lerp(currentRotation, newRotation, t);

        // Apply the interpolated rotation to the object's transform
        transform.rotation = interpolatedRotation;

        // Log the interpolated euler angles
        // Vector3 interpolatedEulerAngles = interpolatedRotation.eulerAngles;
        // Debug.Log("Interpolated Euler Angles: " + interpolatedEulerAngles);
    }
}
