using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D theRB;
    public Animator playerAnimator;
    public float moveSpeed;

    public CameraController camera;
    public static PlayerController instance; // to prevent duplicate players when re-entering spawn zone
    public string areaTransitionName = null;

    private Vector3 bottomLeft;
    private Vector3 topRight;

    // Use this for initialization
    void Awake() {

        if (instance == null) { //if no other player objects have been instanciated
            instance = this;
        }
        else {
            Destroy(gameObject); // else destroy this obj because another player object already exists
        }



        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update() {

        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);

        playerAnimator.SetFloat("moveX", theRB.velocity.x);
        playerAnimator.SetFloat("moveY", theRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {

            playerAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        transform.position =
            new Vector3(
                Mathf.Clamp(transform.position.x, bottomLeft.x, topRight.x),
                Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y),
                this.transform.position.z);
    }

    public void setBounds(Vector3 bottomLeft, Vector3 topRight) {
        /* Function:
        -Sets the bounds of the player controller
        -Player will not be able to move outside of rectangle descibed
        by the bounds
        -Function called by Scenes' CameraController
         */
        this.bottomLeft = bottomLeft + new Vector3(.2f,.2f,0f);
        this.topRight = topRight + new Vector3(-.2f, -.2f, 0f);
    }
}
