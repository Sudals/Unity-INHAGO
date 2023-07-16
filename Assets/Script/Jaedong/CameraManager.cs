
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 touchStartPosition;
    public float moveSpeed = 100000000000000.0f;

    public Transform target;
    public Vector3 offset;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchCurrentPosition = touch.position;
                Vector3 touchDelta = touchCurrentPosition - touchStartPosition;

                float moveX = touchDelta.x * Time.deltaTime * moveSpeed;
                float moveZ = touchDelta.y * Time.deltaTime * moveSpeed;                

                transform.Translate(new Vector3(moveX, 0.0f, moveZ));

                touchStartPosition = touchCurrentPosition;
            }
        } else {
            transform.position = target.position + offset;
        }
    }
}
