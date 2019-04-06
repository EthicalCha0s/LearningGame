using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.125f;

    // Use this for initialization
    void Start() {
        target = PlayerController.instance.transform;
    }

    // LateUpdate is called once per frame after all Updates    
    void LateUpdate() {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, this.transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(this.transform.position,desiredPosition,smoothSpeed);

        this.transform.position = smoothedPosition;
    }
}
