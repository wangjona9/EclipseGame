using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //customizable X and Y sens
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    [SerializeField] Camera fovCamera;

    public ParticleSystem sprintLines;
    public bool enableSprintLines;

    private void Start()
    {
        //locks and hides cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //standard input detection 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        //clamps camera between 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        //DynamicFov();
        //SprintLines();
    }

    private void DynamicFov()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            fovCamera.fieldOfView = Mathf.Lerp(fovCamera.fieldOfView, 80, 10f * Time.deltaTime);
        else 
            fovCamera.fieldOfView = Mathf.Lerp(fovCamera.fieldOfView, 65, 10f * Time.deltaTime);
    }

    private void SprintLines()
    {
        if (enableSprintLines)
            if (Input.GetKey(KeyCode.LeftShift))
                sprintLines.Play();
            else 
                sprintLines.Stop();
    }
}
