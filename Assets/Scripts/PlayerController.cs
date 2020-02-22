using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speed = 500f;
    [SerializeField]private float jump = 100f;


    public LayerMask ground;

    private Rigidbody2D rb;
    private Animator anim;
    private CapsuleCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ground = LayerMask.GetMask("Ground");
        coll = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
        AnimSwitch();
    }

    void PlayerMove()
    {
        float h=Input.GetAxis("Horizontal");
        float hf = Input.GetAxisRaw("Horizontal");
        if(h!=0)
        {
            rb.velocity= new Vector2(h*speed*Time.deltaTime, rb.velocity.y); 
            anim.SetFloat("Run",Mathf.Abs(h));
            if(hf!=0)
                transform.localScale = new Vector3(hf, 1, 1);
        }

        if(Input.GetButtonDown("Jump")&&!anim.GetBool("Jump")&&!anim.GetBool("Fall"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * Time.deltaTime);
            anim.SetBool("Jump", true);
        }
    }

    void AnimSwitch()
    {
        if(anim.GetBool("Jump"))
        {
            if(rb.velocity.y<0)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", true);
            }
        }
        else if(anim.GetBool("Fall")&&coll.IsTouchingLayers(ground))
        {
            anim.SetBool("Fall", false);
        }
    }

}
