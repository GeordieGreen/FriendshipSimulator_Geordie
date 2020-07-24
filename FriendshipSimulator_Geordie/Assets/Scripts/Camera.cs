using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Transform player;
    public Transform subject;
    
    float mouseX;
    float mouseY;

   

    
    void Update()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        

        transform.LookAt(subject);

        
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
