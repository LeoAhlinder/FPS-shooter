using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float Sens = 100f;
    public Transform playerBody;
    float xRotation;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sens * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        xRotation -= mouseY;
    }
}
