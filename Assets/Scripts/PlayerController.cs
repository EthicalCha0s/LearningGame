using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D theRB;
    public float moveSpeed;
    public Animator playerAnimator;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*moveSpeed, Input.GetAxisRaw("Vertical")*moveSpeed);
        playerAnimator.SetFloat("moveX", theRB.velocity.x);
        playerAnimator.SetFloat("moveY", theRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1|| Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {
            playerAnimator.SetFloat("lastMoveX",Input.GetAxisRaw("Horizontal"));
            playerAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            //playerAnimator.SetFloat("lastMoveY", 0);
        }
        /*
        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            playerAnimator.SetFloat("lastMoveX", 0);
        }*/


    }
}
