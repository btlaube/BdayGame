using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Collider2D playerCollider;
    Collider2D thisCollider;
    public int nextRoom;
    public int currentRoom;

    void Start() {
        thisCollider = gameObject.GetComponent(typeof(Collider2D)) as Collider2D;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisCollider.IsTouching(playerCollider) && Input.GetKeyDown("space")) {
            GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().nextRoom(currentRoom, nextRoom);
        }
    }
}
