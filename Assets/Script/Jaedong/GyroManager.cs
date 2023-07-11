using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x, y, z;

        x = -(Input.gyro.rotationRateUnbiased.x) * 2;
        y = -(Input.gyro.rotationRateUnbiased.y) * 2;
        z = -(Input.gyro.rotationRateUnbiased.z) * 2;

        transform.Rotate(x, y, z);
    }
}