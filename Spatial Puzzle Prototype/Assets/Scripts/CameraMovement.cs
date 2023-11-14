using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    float speed = 3;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * speed);
            transform.RotateAround(target.transform.position, transform.right, Input.GetAxis("Mouse Y") * -speed);
        }
    }
}
