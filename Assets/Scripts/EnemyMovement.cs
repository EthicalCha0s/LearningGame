using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float enemySpeed;
    Transform EPosition;
    Rigidbody2D Ebody;
    float EWidth;
    public LayerMask EMask;

	void Start () {
        EPosition = this.transform;
        Ebody = this.GetComponent<Rigidbody2D>();
        EWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	void FixedUpdate () {
        Vector2 lineCastPos = EPosition.position - transform.right * EWidth;
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, EMask);

        if (!isGrounded)
        {
            Vector3 Erotate = EPosition.eulerAngles;
            Erotate.y += 180;
            EPosition.eulerAngles = Erotate;
        }

        Vector2 EVel = Ebody.velocity;
        EVel.x = -EPosition.right.x * enemySpeed;
        Ebody.velocity = EVel;




    }
}
