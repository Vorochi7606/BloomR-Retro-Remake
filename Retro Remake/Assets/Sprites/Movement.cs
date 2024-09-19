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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            anim.SetFloat("horizontal", speed);
            if (facingRight == true)
            {
                Flip();
            }
        }
        if (Input.GetKeyUp(left))
        {
            anim.SetFloat("horizontal", 0);
        }
        if (Input.GetKey(right))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            anim.SetFloat("horizontal", speed);
            if (facingRight == false)
            {
                Flip();
            }
        }
        if (Input.GetKeyUp(right))
        {
            anim.SetFloat("horizontal", 0);
        }
        if (Input.GetKeyDown(up))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speedUp);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
