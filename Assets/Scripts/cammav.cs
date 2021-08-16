using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammav : MonoBehaviour
{
    public float sensitivity = 100;
    public Transform player;
    private float xRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * mousex);
        transform.Rotate(Vector3.left * mousey);
        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation,0,0);
    }
}
