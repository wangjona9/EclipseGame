using UnityEngine;

public class RotateWithCamera : MonoBehaviour
{
    public Camera mainCamera;

    void Update()
    {
        // Check if the main camera is assigned
        if (mainCamera != null)
        {
            // Match the rotation of the camera on the y-axis
            transform.rotation = Quaternion.Euler(0f, mainCamera.transform.eulerAngles.y, 0f);
        }
        else
        {
            Debug.LogWarning("Main camera not assigned. Please assign the main camera in the inspector.");
        }
    }
}