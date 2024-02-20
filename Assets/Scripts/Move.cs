using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;
    private float horizontalMove;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
    }

    public void PointerDownLeft() {
        moveLeft = true;
    }

    public void PointerUpLeft() {
        moveLeft = false;
    }
    
    public void PointerDownRight() {
        moveRight = true;
    }

    public void PointerUpRight() {
        moveRight = false;
    }


    // Update is called once per frame
    public void Update()
    {
        MovePlayer();
    }

    private void MovePlayer() {
        if(moveLeft) {
            horizontalMove = -speed;
        }
        else if (moveRight) {
            horizontalMove = speed;
        }
        else {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(horizontalMove, rb.velocity.y);
    }
}
