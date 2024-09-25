using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public Animator anim;
    public float speed;
    public float speedUp;
    public bool facingRight = false;
    private bool isJumping;
    private bool isGrounded;
    public LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.BoxCast(transform.position + Vector3.down, new Vector2(1, 0.1f), 0, Vector2.one, 0, groundLayer);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFalling", isGrounded == false && GetComponent<Rigidbody2D>().velocity.y < -2);
        if (Input.GetKey(left))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            anim.SetBool("isMoving", true);
            if (facingRight == true)
            {
                Flip();
            }
        }
        if (Input.GetKeyUp(left))
        {
            anim.SetBool("isMoving", false);
        }
        if (Input.GetKey(right))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            anim.SetBool("isMoving", true);
            if (facingRight == false)
            {
                Flip();
            }
        }
        if (Input.GetKeyUp(right))
        {
            anim.SetBool("isMoving", false);
        }
        if (Input.GetKeyDown(up))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speedUp);
            anim.SetBool("isJumping", true);
            isJumping = true;
        }
        if (isJumping = true && GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            isJumping = false;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == ("Ground"))
    //    {
    //        isGrounded = true;
    //        anim.SetBool("isGrounded", true);
    //        anim.SetBool("isFalling", false);
    //    }
    //}

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == ("Ground"))
    //    {
    //        isGrounded = false;
    //        anim.SetBool("isGrounded", false);
    //    }
    //}
}
