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
        float y;

        y = -(Input.gyro.rotationRateUnbiased.y) * 2;
        transform.Rotate(0, y, 0);
    }
}