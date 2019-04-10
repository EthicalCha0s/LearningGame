using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.05f;

    public int maxX, maxY, minX, minY;


    // Use this for initialization
    void Start() {
        target = PlayerController.instance.transform;
    }

    // LateUpdate is called once per frame after all Updates    
    void LateUpdate() {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, this.transform.position.z);

        // statements below make it impossible for the camera to go out of bounds
        if (desiredPosition.x >= maxX) {
            desiredPosition.x = maxX;
        }
        if (desiredPosition.x <= minX) {
            desiredPosition.x = minX;
        }
        if (desiredPosition.y >= maxY) {
            desiredPosition.y = maxY;
        }
        if (desiredPosition.y <= minY) {
            desiredPosition.y = minY;
        }

        Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, smoothSpeed);

        this.transform.position = smoothedPosition;
    }
}
