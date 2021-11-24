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
    private bool startedMove = false;
    private float numFollowers;

    public float speed = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    Vector2 direction;

    public float X;
    public float Y;
    

    void Update() {       

        if (target.position.x < transform.position.x) {
            targetLocation.x = target.position.x + (numFollowers * followDistance);
        }
        else if (target.position.x > transform.position.x) {
            targetLocation.x = target.position.x - (numFollowers * followDistance);
        }

        direction.x = transform.position.x - targetLocation.x;

        direction = -direction.normalized;

        if (Mathf.Abs(transform.position.x - target.position.x) <= range && !startedMove) {
            startedMove = true;
            startMove = true;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioManager>().Play("Collect");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().addFollower();
            numFollowers = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getNumFollowers();
            transform.parent = target;
            Debug.Log(numFollowers);
        }

    }

    void FixedUpdate()
    {
        if (startMove && Mathf.Abs(transform.position.x - targetLocation.x) > (numFollowers * followDistance)) {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    public void lastRoom() {
        transform.parent = GameObject.Find("Room9").transform;
        gameObject.GetComponent<Follow>().enabled = false;
        transform.position = new Vector2(X, Y);
    }

}
