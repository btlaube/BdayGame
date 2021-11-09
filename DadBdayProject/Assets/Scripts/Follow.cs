using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    
    public Transform target;
    Vector2 targetLocation;
    public float followDistance;
    private bool move;
    private bool startMove = false;
    public float range;

    public float speed = 5f;
    public Rigidbody2D rb;
    //public Animator animator;
    public SpriteRenderer sr;
    Vector2 direction;

    void Update() {
        
        if (target.position.x < transform.position.x) {
            targetLocation.x = target.position.x + followDistance;
            //sr.flipX = true;
        }
        else if (target.position.x > transform.position.x) {
            targetLocation.x = target.position.x - followDistance;
            //sr.flipX = false;
        }

        direction.x = transform.position.x - targetLocation.x;

        direction = -direction.normalized;

        if (Mathf.Abs(transform.position.x - targetLocation.x) <= range) {
            startMove = true;
        }

    }

    void FixedUpdate()
    {
        if (startMove && Mathf.Abs(transform.position.x - targetLocation.x) > followDistance) {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }


}
