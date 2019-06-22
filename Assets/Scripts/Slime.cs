/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slime : MonoBehaviour
{
    public Rigidbody2D theRB;
    public Animator NPCAnimator;
    public float moveSpeed;

    //public static PlayerController instance; // to prevent duplicate players when re-entering spawn zone
    public string areaTransitionName = null;
    void Update()
        {

            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);

            NPCAnimator.SetFloat("moveX", theRB.velocity.x);
            NPCAnimator.SetFloat("moveY", theRB.velocity.y);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {

                NPCAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                NPCAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator anim;
    private float Speed = 6.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}