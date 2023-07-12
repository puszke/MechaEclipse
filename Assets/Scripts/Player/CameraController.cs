using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cam_speed = 10;
    private float xRotation;
    private float yRotation;
    private float tilt = 0;

    public Transform orientation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void tilt_cam()
    {
        float s = Input.GetAxisRaw("Horizontal");

        if (tilt < s * 2.5f)
            tilt += 0.1f;
        else if(tilt>s* 2.5f)
            tilt -= 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        tilt_cam();
       
        float mouseX = Input.GetAxisRaw("Mouse X") * cam_speed;
        float mouseY = Input.GetAxisRaw("Mouse Y") * cam_speed;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, -tilt);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
    private void FixedUpdate()
    {
       
    }
}
