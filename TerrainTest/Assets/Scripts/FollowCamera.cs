using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerCamera;
    public float yoffset = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = playerCamera.position;
        newPosition.y = yoffset;
        this.transform.position = newPosition;
    }
}
