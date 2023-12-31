using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
   public float sensX;
   public float sensY;

   private Transform orientation;


   float xRotation;
   float yRotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime *sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime *sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation = Quaternion.Euler(0,yRotation,0);

    }
}
