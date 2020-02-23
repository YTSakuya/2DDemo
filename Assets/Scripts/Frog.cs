using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Monster
{
    private Animator anim;
    private Rigidbody2D rb;

    private float time = 2f;
    private float jump = 300;
    private float dir = -1;

    private LayerMask ground;
    private CapsuleCollider2D coll;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ground = LayerMask.GetMask("Ground");
        coll = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        AnimSwitch();
    }

    void AnimSwitch()
    {
        if(anim.GetBool("Idle"))
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = Time.time;
                anim.SetBool("Idle",false);
                anim.SetBool("Jump", true);
                rb.velocity = new Vector2(dir*jump*Time.deltaTime,jump*Time.deltaTime);
                Debug.Log("jump");
            }
        }else if(anim.GetBool("Jump"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", true);
            }
        }else if(anim.GetBool("Fall")&&coll.IsTouchingLayers(ground))
        {
            if(rb.velocity.y==0)
            {
                anim.SetBool("Fall", false);
                anim.SetBool("Idle", true);
                time = 2;
                transform.localScale = new Vector3(dir, 1, 1);
                dir *= -1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("Die");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="BackGround")
        {
            Destroy(this.gameObject);
        }
    }
}
