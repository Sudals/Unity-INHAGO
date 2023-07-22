
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public int camSpeed = 10;

    void Update()
    {
        float camRotate = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * camSpeed * Time.deltaTime * camRotate);


        transform.position = target.position + offset;
    }
}
