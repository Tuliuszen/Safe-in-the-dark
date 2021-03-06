using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float mouseSensivity = 100f;
    public Transform playerTransform;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
       
    }

    // Update is called once per frame
    void Update()
    {
        RotateMouse();
    }

    void RotateMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
