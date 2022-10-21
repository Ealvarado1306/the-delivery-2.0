using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public Rigidbody rb;
    public float buttonTime = 0.3f;
    public float jumpAmount = 20;
    float jumpTime;
    bool jumping;
    Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            jumping = true;
            jumpTime = 0;
        }
        if(jumping)
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpAmount);
            jumpTime += Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }
    }
}
