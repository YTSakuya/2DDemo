using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Monster
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Destroy(this.gameObject);
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
