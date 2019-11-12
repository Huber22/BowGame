using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    //lock camera on rotation based of of reference 
    private float xAxisClamp;

    //lock the cursor to center of screen at start of game
    private void Awake()
    {
        LookCursor();
        xAxisClamp = 0.0f;
    }
    //lock the cursor to center of screen
    private void LookCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }
    //get rotaion of camera and rotate it
    private void CameraRotation()
    {
        float mouseX = Input.GetAxisRaw(mouseXInputName) * mouseSensitivity;
        float mouseY = Input.GetAxisRaw(mouseYInputName) * mouseSensitivity;

        //Record the amount of rotation applied to our camera
        xAxisClamp += mouseY;

        //clamp the camera rotation if exceeding more than 90 in positive and negitive
        if(xAxisClamp >90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotaionToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotaionToValue(90.0f);
        }

        //Rotate fuction transform and put in vector 3 value(amount we want ot rotate the camera)
        transform.Rotate(Vector3.left * mouseY);
        //move on y axis
        playerBody.Rotate(Vector3.up * mouseX);

    }

    //convert to euler rotation for smoother rotations
    //stops camera rotaions exceeding the clamp
    private void ClampXAxisRotaionToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;

    }
}
