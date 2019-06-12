using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Tilemap theMap;
    public Vector3 bottomLeft; //Bottom left camera limit
    public Vector3 topRight; //top right camera limit

    public float halfHeight;
    public float halfWidth;

    public float smoothSpeed = 0.05f;
    public int maxX, maxY, minX, minY;


    // Use this for initialization
    void Start() {
        target = PlayerController.instance.transform;
        if (minY > maxY || minX > maxX) {
            throw (new UnityException("CameraController.cs script badly initialized"));
        }
        //getting the camera size
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        //setting the camera bounds
        bottomLeft = theMap.localBounds.min+ new Vector3(halfWidth,halfHeight,0f);
        topRight = theMap.localBounds.max + new Vector3(halfWidth,halfHeight,0f);
        
        PlayerController.instance.camera = this;
    }

    // LateUpdate is called once per frame after all Updates    
    void LateUpdate() {
        Vector3 desiredPosition =
            new Vector3(//Keeps camera within set bounds
                Mathf.Clamp(target.position.x, bottomLeft.x, topRight.x),
                Mathf.Clamp(target.position.y, bottomLeft.y, topRight.y),
                this.transform.position.z);

        //smoothes camera opsition
        Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, smoothSpeed); //Camera smoothes towards desired position
        this.transform.position = smoothedPosition;
    }
}
